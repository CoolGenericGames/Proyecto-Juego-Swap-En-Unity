using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    #region CONSTANTES

    /// <summary>
    /// Tiempo que durará el mensaje en pantalla.
    /// </summary>
    private const float TIEMPO_MENSAJE = 0.4f;
    /// <summary>
    /// Tiempo que durará el mensaje en pantalla si fue un error.
    /// </summary>
    private const float TIEMPO_MENSAJE_ERROR = 0.8f;

    #endregion

    #region COMPONENTES

    [Header("TEXTOS DE INFORMACIÓN")] // -------------------------------------------
    /// <summary>
    /// Referencia al campo de texto donde se muestran mensajes, como errores, advertencias.
    /// </summary>
    public Text textoMensaje;
    /// <summary>
    /// Referencia al campo de texto donde se muestra el nombre del jugador.
    /// </summary>
    public Text textoNombreJugador;
    /// <summary>
    /// Referencia al campo de texto donde se muestra la puntuación de la partida actual.
    /// </summary>
    public Text textoPuntuacion;
    /// <summary>
    /// Referencia al campo de texto donde se muestra las vidas extra del jugador.
    /// </summary>
    public Text textoVidas;


    [Header("TEXTOS DE FIN DE JUEGO")] // ------------------------------------------
    public Text textoFinJuego;


    [Header("PANELES")] // ---------------------------------------------------------
    /// <summary>
    /// Panel que contiene la información de la partida.
    /// </summary>
    public GameObject panelInfoJuego;
    /// <summary>
    /// Panel que contiene los elementos del fin de juego.
    /// </summary>
    public GameObject panelFinJuego;

    #endregion

    #region MÉTODOS DE UNITY

    // Suscribimos los métodos a los eventos pertinentes.
    private void OnEnable()
    {
        ControladorNave.evntMensajeInput += MostrarMensajeInput;
        ControladorNave.evntNombre       += ActualizarNombreJugador;
        ControladorNave.evntVida         += ActualizarVidasJugador;

        DatosJugador.evntPuntuacion      += ActualizarPuntuacionJugador;

        ControladorRutinas.evntVictoria  += PartidaGanada;
    }

    // Se desuscriben todos los métodos de sus eventos.
    private void OnDisable()
    {
        ControladorNave.evntMensajeInput -= MostrarMensajeInput;
        ControladorNave.evntNombre       -= ActualizarNombreJugador;
        ControladorNave.evntVida         -= ActualizarVidasJugador;

        DatosJugador.evntPuntuacion      -= ActualizarPuntuacionJugador;

        ControladorRutinas.evntVictoria  -= PartidaGanada;


    }

    // Inicializamos las variables y componentes.
    private void Start()
    {
        // TEXTOS DE INFORMACIÓN -------------------------------------------------------
        textoMensaje.text       = string.Empty;
        textoNombreJugador.text = string.Empty;
        textoVidas.text         = string.Empty;

        textoPuntuacion.text    = "0";

        // PANELES ---------------------------------------------------------------------
        panelInfoJuego.SetActive(true);
        panelFinJuego.SetActive(false);
    }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Método que mostrará un mensaje en pantalla durante un breve periodo de tiempo si ocurre un error
    /// con el sipositivo de entrada.
    /// </summary>
    /// <param name="_mensaje"> Mensaje que se mostrará. </param>
    /// <param name="_esError"> Permite saber si ocurrio un error o es solo una advertencia. </param>
    private void MostrarMensajeInput(string _mensaje, bool _esError)
    {
        StartCoroutine(MostrarMensaje(_mensaje, _esError));
    }

    /// <summary>
    /// Método que actualiza el nombre del jugador.
    /// </summary>
    /// <param name="_nombre"> El nombre del jugador. </param>
    private void ActualizarNombreJugador(string _nombre) { textoNombreJugador.text = _nombre; }

    /// <summary>
    /// Método que actualiza las vidas del jugador.
    /// </summary>
    /// <param name="_vidas">Número de vidas extra que tiene el jugador.</param>
    private void ActualizarVidasJugador(int _vidas) 
    { 
        if (_vidas >= 0)
        {
            textoVidas.text = "Vidas extra: " + _vidas; 
        } 
        else
        {
            // Se activa el panel de fin de juego.
            panelFinJuego.SetActive(true);
            textoFinJuego.text = "PERDISTE";

            // Se desactiva el panel de información.
            panelInfoJuego.SetActive(false);
        }
    }

    /// <summary>
    /// Método que actualiza la puntuación del jugador.
    /// </summary>
    /// <param name="_puntuacion">Puntuación del jugador.</param>
    private void ActualizarPuntuacionJugador(int _puntuacion)
    {
        textoPuntuacion.text = _puntuacion.ToString();
    }


    private void PartidaGanada()
    {
        // Se activa el panel de fin de juego.
        panelFinJuego.SetActive(true);
        textoFinJuego.text = "GANASTE";

        // Se desactiva el panel de información.
        panelInfoJuego.SetActive(false);
    }

    #endregion

    #region MÉTODOS PUBLICOS

    /// <summary>
    /// Método que es invocado por un botón para regresar al menu.
    /// </summary>
    public void RegresarAlLobby() { SceneManager.LoadScene("Lobby", LoadSceneMode.Single); }

    #endregion

    #region RUTINAS

    /// <summary>
    /// Rutina encargada de mostrar un mensaje en pantalla por unos segundos.
    /// </summary>
    /// <param name="_mensaje">El mensaje que se mostrará.</param>
    /// <param name="_esError">Permite saber si ocurrio un error o es solo una advertencia.</param>
    /// <returns></returns>
    private IEnumerator MostrarMensaje(string _mensaje, bool _esError)
    {
        textoMensaje.text = _mensaje;

        if (_esError) yield return new WaitForSeconds(TIEMPO_MENSAJE_ERROR);
        else yield return new WaitForSeconds(TIEMPO_MENSAJE);

        textoMensaje.text = string.Empty;
    }

    #endregion
}
