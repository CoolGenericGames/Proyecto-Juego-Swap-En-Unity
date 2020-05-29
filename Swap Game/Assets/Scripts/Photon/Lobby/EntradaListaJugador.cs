using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntradaListaJugador : MonoBehaviour
{
    #region VARIABLES

    // DATOS JUGADOR ---------------------------------------------------------------
    /// <summary>
    /// ID de photon.
    /// </summary>
    private int photonID;
    /// <summary>
    /// Indica si el jugador esta listo para la partida.
    /// </summary>
    private bool estaListo;

    #endregion

    #region COMPONENTES

    [Header("TEXTOS")] // ----------------------------------------------------------
    /// <summary>
    /// Texto que muestra el nombre del jugador.
    /// </summary>
    public Text textoNombreJugador;


    [Header("IMAGEN")] // ----------------------------------------------------------
    /// <summary>
    /// Imagen que muestra el color del jugador.
    /// </summary>
    public Image imagenColorJugador;
    /// <summary>
    /// Imagen que permite saber que el jugador esta listo para la partida.
    /// </summary>
    public Image imagenListo;


    [Header("BOTONES")] // ---------------------------------------------------------
    /// <summary>
    /// Botón que permite hacer saber que el jugador esta listo para la partida.
    /// </summary>
    public Button botonJugadorListo;

    #endregion

    #region MÉTODOS UNITY

    // Suscribimos los métodos a los eventos.
    private void OnEnable()
    {
        PlayerNumbering.OnPlayerNumberingChanged += ActualizarColores;
    }

    // Desuscribimos los métodos a los eventos.
    private void OnDisable()
    {
        PlayerNumbering.OnPlayerNumberingChanged -= ActualizarColores;

    }

    // Se inicializa la entrada con los datos.
    private void Start()
    {
        // Si no es el jugador local, se desactiva el botón que indica que el jugador esta listo.
        if (PhotonNetwork.LocalPlayer.ActorNumber != photonID)
        {
            botonJugadorListo.enabled = false;
        }
        // Si es el jugador local, se establecen sus propiedades.
        else
        {
            Hashtable propiedadesIniciales = new Hashtable()
            {
                { Constantes.JUGADOR_LISTO, estaListo },
                { Constantes.JUGADOR_VIDAS, Constantes.JUGADOR_NUM_VIDAS }
            };

            PhotonNetwork.LocalPlayer.SetCustomProperties(propiedadesIniciales);
            PhotonNetwork.LocalPlayer.SetScore(0);

            // Se le añade una función al botón.
            botonJugadorListo.onClick.AddListener(() =>
            {
                // Se indica que el jugador esta listo.
                estaListo = !estaListo;
                JugadorListo(estaListo);

                // Se actualizan las propiedades del jugador.
                Hashtable propiedades = new Hashtable()
                {
                    { Constantes.JUGADOR_LISTO, estaListo }
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(propiedades);

                if (PhotonNetwork.IsMasterClient)
                    FindObjectOfType<PanelPrincipalLobby>().ActualizarPropiedadesDelJugador();
            });

            imagenListo.enabled = estaListo;
        }
    }

    #endregion

    #region MÉTODOS PRIVADOS (INICIALIZAR)

    /// <summary>
    /// Método que permite inicializar los valores de la entrada dle jugador.
    /// </summary>
    /// <param name="_photonID">ID de photon del jugador.</param>
    /// <param name="_nombreJugador">Nombre del jugador.</param>
    public void Inicializar(int _photonID, string _nombreJugador)
    {
        photonID = _photonID;
        textoNombreJugador.text = _nombreJugador;
    }

    /// <summary>
    /// Método que cambia los valores dependiendo si el jugador está listo para la partida o no.
    /// </summary>
    /// <param name="_jugadorListo">Indica si el jugador esta listo o no para la partida.</param>
    public void JugadorListo(bool _jugadorListo)
    {
        botonJugadorListo.GetComponentInChildren<Text>().text = _jugadorListo ? "Listo!" : "Listo?";
        imagenListo.enabled = _jugadorListo;
    }

    /// <summary>
    /// Método que actualiza los colores de los jugadores.
    /// </summary>
    private void ActualizarColores()
    {
        /*
        foreach(Player jugador in PhotonNetwork.PlayerList)
        {
            if (jugador.ActorNumber == photonID)
            {
                imagenColorJugador.color = Constantes.ObtenerColor(jugador.GetPlayerNumber());
                imagenListo.color = Constantes.ObtenerColor(jugador.GetPlayerNumber());
            }
        }
        */
    }

    #endregion
}
