using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntradaListaPartidas : MonoBehaviour
{
    #region VARIABLES

    // TEXTOS ----------------------------------------------------------------------
    /// <summary>
    /// Nombre de la partida.
    /// </summary>
    private string nombrePartida;

    #endregion

    #region COMPONENTES

    [Header("TEXTOS")] // ----------------------------------------------------------
    /// <summary>
    /// Texto que muestra el nombre de la partida.
    /// </summary>
    public Text textoNombrePartida;
    /// <summary>
    /// Texto que muestra el nombre del jugador.
    /// </summary>
    public Text textoNumJugadores;
    /// <summary>
    /// Botón quee permite entrar en una partida.
    /// </summary>
    public Button botonEntrarPartida;

    #endregion

    #region MÉTODOS UNITY

    public void Start()
    {
        botonEntrarPartida.onClick.AddListener(() =>
        {
            if (PhotonNetwork.InLobby)
                PhotonNetwork.LeaveLobby();

            PhotonNetwork.JoinRoom(nombrePartida);
        });
    }

    #endregion

    #region MÉTODOS PRIVADOS (INICIALIZAR)

    /// <summary>
    /// Método que permite inicializar la entrada.
    /// </summary>
    /// <param name="_nombre">Nombre de la partida.</param>
    /// <param name="_numJugadores">Número actual de jugadores en la partida.</param>
    /// <param name="_maxJugadores">Número máximo de jugadores.</param>
    public void Inicializar(string _nombre, byte _numJugadores, byte _maxJugadores)
    {
        nombrePartida = _nombre;

        textoNombrePartida.text = _nombre;
        textoNumJugadores.text  = _numJugadores + " / " + _maxJugadores;
    }

    #endregion
}
