using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour
{
    #region ACCIONES Y EVENTOS

    /// <summary>
    /// Evento que es invocado cuando se actualizan la puntuación del jugador.
    /// </summary>
    public static Action<int> evntPuntuacion;

    #endregion

    #region SINGLETON

    /// <summary>
    /// Single instance containing the user's important PlayFab data.
    /// </summary>
    private static DatosJugador _instancia;

    #endregion

    #region VARIABLES

    /// <summary>
    /// Puntuación actual del jugador.
    /// </summary>
    private int puntuacion;

    /// <summary>
    /// Puntuación máxima del jugador.
    /// </summary>
    private int puntuacionMaxima;

    #endregion

    #region PROPIEDADES

    /// <summary>
    /// Permite acceder al los datos de PlayFab del jugador.
    /// </summary>
    public static DatosJugador Get { get => _instancia; }

    /// <summary>
    /// Nombre del jugador.
    /// </summary>
    public string Nombre { get; set; }
    
    /// <summary>
    /// ID único del jugador.
    /// </summary>
    public string PlayFabID { get; set; }

    /// <summary>
    /// Puntuacion del jugador.
    /// </summary>
    public int Puntuacion 
    {
        get => puntuacion;

        set
        {
            puntuacion = value;

            evntPuntuacion?.Invoke(puntuacion);
        }
    }

    #endregion
    
    #region MÉTODOS DE UNITY

    private void Awake()
    {
        // Inicializamos el singleton.
        _instancia = this;
        
        // Prevenimos que el objeto sea destruido al cargar escenas.
        DontDestroyOnLoad(this.gameObject);
    }

    // Se inicializan las variables.
    private void Start() => puntuacion = 0;

    #endregion

    #region ACTUALIZAR DATOS

    /// <summary>
    /// Método que permite actualizar las estadisticas del jugador.
    /// </summary>
    public void ActualizarPuntuacion()
    {
        // Si la puntuación actual es mayor a la puntuación máxima del usuario se actualiza.
        if (puntuacion > puntuacionMaxima)
        {
            PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "PuntuacionMaxima", Value = puntuacion },
            }
            }, result => { Debug.Log("Datos actualizados"); ObtenerDatos(); },
            error => { Debug.Log(error.GenerateErrorReport()); });
        } 
        // Si la puntuación actual no es mayor a la puntuación máxima, se reinicia el acumulador.
        else
        {
            puntuacion = 0;
        }
    }

    #endregion

    #region OBTENER DATOS

    /// <summary>
    /// Método que permite obtener las estadísticas del jugador en PlayFab.
    /// </summary>
    public void ObtenerDatos()
    {
        PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest(),
            ObtenerDatosExito,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    /// <summary>
    /// Método que asigna los valores de las estadísticas obtenidas con el método GetStats a sus respectivas variables.
    /// </summary>
    /// <param name="_result"></param>
    private void ObtenerDatosExito(GetPlayerStatisticsResult _result)
    {
        // Se borra el contenido de las variables para evitar problemas.
        puntuacion = 0;
        puntuacionMaxima = 0;

        // Se añaden las nuevas puntuaciones.
        foreach (var statistic in _result.Statistics)
        {
            switch (statistic.StatisticName)
            {
                case "PuntuacionMaxima":
                    puntuacionMaxima = statistic.Value;
                    Debug.Log("Puntuación Máxima: " + puntuacionMaxima);
                    break;
                default:
                    ActualizarPuntuacion();
                    break;
            }
        }
    }

    #endregion
}
