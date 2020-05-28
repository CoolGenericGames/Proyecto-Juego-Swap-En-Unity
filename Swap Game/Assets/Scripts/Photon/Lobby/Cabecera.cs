using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cabecera : MonoBehaviour
{
    #region VARIABLES

    // TEXTO -----------------------------------------------------------------------
    /// <summary>
    /// Parte inicial del texto de estado de conexión.
    /// </summary>
    private readonly string mensajeEstadoConexion = "Estado de la conexción: ";

    #endregion

    #region COMPONENTES

    [Header("TEXTOS")] // ----------------------------------------------------------
    /// <summary>
    /// Referencia al campo de texto donde se mostrará el estado de la conexión.
    /// </summary>
    public TextMeshProUGUI textoEstadoConexion;

    #endregion

    #region MÉTODOS UNITY

    private void Update()
    {
        textoEstadoConexion.text = mensajeEstadoConexion + PhotonNetwork.NetworkClientState;
    }

    #endregion
}
