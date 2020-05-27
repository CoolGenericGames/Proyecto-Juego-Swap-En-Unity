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

    private int puntuacion;

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

    private void Start() => puntuacion = 0;

    #endregion
}
