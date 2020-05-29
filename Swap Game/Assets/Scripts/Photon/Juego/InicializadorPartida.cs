using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorPartida : MonoBehaviourPunCallbacks
{
    #region COMPONENTES

    // PHOTON ----------------------------------------------------------------------
    /// <summary>
    /// Referencia al componente photonView
    /// </summary>
    private PhotonView pv;


    [Header("PUNTOS DE SPAWN")] // -------------------------------------------------
    /// <summary>
    /// Referencia a la posición del punto de spawn 1.
    /// </summary>
    public Transform puntoDeSpawn1;
    /// <summary>
    /// Referencia a la posición del punto de spawn 2.
    /// </summary>
    public Transform puntoDeSpawn2;

    #endregion

    #region MÉTODOS DE UNITY

    // Se inicializan los componentes.
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    // Se sincroniza la escena y se declara que el jugador cardo nivel.
    private void Start()
    {
        // Sincronizamos los clientes con el servidor.
        PhotonNetwork.AutomaticallySyncScene = true;

        // Declaramos que el jugador ya tiene el nivel cargado.
        Hashtable nuevasPropiedades = new Hashtable
        {
            { Constantes.JUGADOR_NIVEL_CARGADO, true }
        };
        PhotonNetwork.LocalPlayer.SetCustomProperties(nuevasPropiedades);
    }

    #endregion

    #region MÉTODOS DE PHOTON

    /// <summary>
    /// Método que es invocado cuando se pierde la conexión.
    /// </summary>
    /// <param name="_causa"></param>
    public override void OnDisconnected(DisconnectCause _causa)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    /// <summary>
    /// Método que es invocado cuando se abandona la partida.
    /// </summary>
    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    /// <summary>
    /// Método que es invocado cuando se cambia de Master.
    /// </summary>
    /// <param name="_nuevoMasterClient"></param>
    public override void OnMasterClientSwitched(Player _nuevoMasterClient)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == _nuevoMasterClient.ActorNumber)
        {
            Debug.Log("Ahora eres el Master!");
        }
    }

    /// <summary>
    /// Método que es llamado cuando otro jugador abandona la partida.
    /// </summary>
    /// <param name="_otroJugador"></param>
    public override void OnPlayerLeftRoom(Player _otroJugador)
    {
        //CheckEndOfGame();
    }

    /// <summary>
    /// Método que es llamado cuando un jugador actualiza sus propiedades.
    /// </summary>
    /// <param name="_jugadorObjetivo"></param>
    /// <param name="_nuevasPropiedades"></param>
    public override void OnPlayerPropertiesUpdate(Player _jugadorObjetivo, Hashtable _nuevasPropiedades)
    {
        if (_nuevasPropiedades.ContainsKey(Constantes.JUGADOR_NUM_VIDAS))
        {
            //CheckEndOfGame();
            return;
        }

        // Si no somos el master regresamos el control.
        if (!PhotonNetwork.IsMasterClient) return;

        // Revisamos que todos los jugadores cargarán el nivel.
        if (_nuevasPropiedades.ContainsKey(Constantes.JUGADOR_NIVEL_CARGADO))
        {
            if (RevisarJugadoresListos())
            {
                pv.RPC("IniciarPartida", RpcTarget.AllViaServer);
            }
        }
    }

    #endregion

    #region MÉTODOS RPC DE PHOTON

    /// <summary>
    /// Método que se encarga de instanciar al jugador.
    /// </summary>
    [PunRPC] private void IniciarPartida()
    {
        Vector3 posicionNuevoJugador;

        // Se asignan la posicion de spawn de los jugadores.
        if (PhotonNetwork.LocalPlayer.GetPlayerNumber() == 0)
            posicionNuevoJugador = puntoDeSpawn1.transform.position;
        else
            posicionNuevoJugador = puntoDeSpawn2.transform.position;

        // Se instancia al jugador (nave).
        GameObject nuevaNave = PhotonNetwork.Instantiate("Nave", posicionNuevoJugador, Quaternion.identity);
        nuevaNave.GetComponent<ControladorNave>().Piloto = PhotonNetwork.LocalPlayer;
    }

    #endregion

    #region MÉTODOS PARTIDA

    /// <summary>
    /// Método que nos permite revisar si todos los jugadores están listos.
    /// </summary>
    /// <returns></returns>
    private bool RevisarJugadoresListos()
    {
        foreach (Player jugador in PhotonNetwork.PlayerList)
        {
            object jugadorListo;

            if (jugador.CustomProperties.TryGetValue(Constantes.JUGADOR_NIVEL_CARGADO, out jugadorListo))
            {
                if ((bool)jugadorListo) continue;
            }

            return false;
        }

        return true;
    }


    #endregion
}
