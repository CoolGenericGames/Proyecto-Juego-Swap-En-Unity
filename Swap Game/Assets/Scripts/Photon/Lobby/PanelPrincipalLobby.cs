using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPrincipalLobby : MonoBehaviourPunCallbacks
{
    #region VARIABLES

    // INFORMACIÓN -----------------------------------------------------------------
    /// <summary>
    /// Almacena la información de la lista de partidas encontradas.
    /// </summary>
    private Dictionary<string, RoomInfo> cacheListaPartidas;
    /// <summary>
    /// Contiene la información de las entradas de la lista de partidas encontradas.
    /// </summary>
    private Dictionary<string, GameObject> entradasListaPartidas;
    /// <summary>
    /// Contiene la información de las entradas de la lista de jugadores.
    /// </summary>
    private Dictionary<int, GameObject> entradasListaJugador;

    #endregion

    #region COMPONENTES

    [Header("PANEL CONECTAR")] // --------------------------------------------------
    /// <summary>
    /// Panel que permite iniciar sesión en Photon.
    /// </summary>
    public GameObject panelConectar;
    /// <summary>
    /// Referencia al texto donde se mostrara el nombre del jugador.
    /// </summary>
    public Text textoNombreJugador;


    [Header("PANEL MENU")] // ------------------------------------------------------
    /// <summary>
    /// Panel que muestra las opciones de menú.
    /// </summary>
    public GameObject panelMenu;


    //[Header("PANEL CREAR PARTIDA")] // ---------------------------------------------
    /// <summary>
    /// Panel que muestra las opciones para crear una partida.
    /// </summary>
    //public GameObject panelCrearPartida;


    [Header("PANEL UNIRSE")] // ----------------------------------------------------
    /// <summary>
    /// Panel que muestra las opciones para unirse a una partida aleatoria.
    /// </summary>
    public GameObject panelUnirse;


    [Header("PANEL LISTA DE PARTIDAS")] // -----------------------------------------
    /// <summary>
    /// Panel que muestra la lista de partidas.
    /// </summary>
    public GameObject panelListaPartidas;
    /// <summary>
    /// Contenido del panel de listas de partidas.
    /// </summary>
    public GameObject contenidoListaPartidas;
    /// <summary>
    /// Muestra la información de un elemento en la lista.
    /// </summary>
    public GameObject prefabEntradaListaPartidas;


    [Header("PANEL PARTIDA")] // ---------------------------------------------------
    /// <summary>
    /// Panel que muestra la información de la partida.
    /// </summary>
    public GameObject panelPartida;
    /// <summary>
    /// Muestra la información de un jugador en la lista.
    /// </summary>
    public GameObject prefabEntradaListaJugador;


    [Header("BOTONES")] // ---------------------------------------------------------
    /// <summary>
    /// Panel que muestra la información de la partida.
    /// </summary>
    public Button botonIniciarJuego;

    #endregion

    #region MÉTODOS DE UNITY

    // Se inicializan las variables.
    private void Awake()
    {
        // Se sincroniza la escena con photon.
        PhotonNetwork.AutomaticallySyncScene = true;

        // Se inicializan los diccionarios.
        cacheListaPartidas    = new Dictionary<string, RoomInfo>();
        entradasListaPartidas = new Dictionary<string, GameObject>();

        // Se coloca el nombre dle jugador.
        textoNombreJugador.text = DatosJugador.Get.Nombre;
    }

    #endregion

    #region MÉTODOS UI (BOTONES)

    /// <summary>
    /// Método que te permite regresar al panel del menú.
    /// </summary>
    public void OnClickBotonRegresar()
    {
        if (PhotonNetwork.InLobby) PhotonNetwork.LeaveLobby();

        ActivarPanel(panelMenu.name);
    }

    /// <summary>
    /// Método que permite crear una partida.
    /// </summary>
    public void OnClickBotonCrearPartida()
    {
        // El nombre de la partida será el nombre dle jugador.
        string nombrePartida = DatosJugador.Get.Nombre;

        // El máximo de jugadores por partida siempre será 2.
        byte maxJugadores = Constantes.MAXIMO_JUGADORES_PARTIDA;

        // Se configura la partida.
        RoomOptions opciones = new RoomOptions { MaxPlayers = maxJugadores };

        // Se crea la partida.
        PhotonNetwork.CreateRoom(nombrePartida, opciones, null);
    }

    /// <summary>
    /// Método que nos permite unirnos a una partida aleatoria.
    /// </summary>
    public void OnCLickBotonUnirsePartida()
    {
        ActivarPanel(panelUnirse.name);

        PhotonNetwork.JoinRandomRoom();
    }

    /// <summary>
    /// Método que nos permite abandonar una partida.
    /// </summary>
    public void OnCLickBotonSalirPartida()
    {
        PhotonNetwork.LeaveRoom();
    }

    /// <summary>
    /// Método que nos permite iniciar sesión en Photon.
    /// </summary>
    public void OnClickBotonIniciarSesion()
    {
        // Obtener el nombre del jugador.
        string nombreJugador = DatosJugador.Get.Nombre;

        // Asignamoes el nombre del jugador en Photon.
        PhotonNetwork.LocalPlayer.NickName = nombreJugador;

        // Conectamos con Photon.
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// Método que permite acceder al panel que muestra la lista de partidas.
    /// </summary>
    public void OnCLickBotonListaPartidas()
    {
        // Si el usuario no se encuentra en el lobby, entra en el lobby.
        if (!PhotonNetwork.InLobby) { PhotonNetwork.JoinLobby(); }

        // Se activa el panel de la lista de partidas.
        ActivarPanel(panelListaPartidas.name);
    }

    /// <summary>
    /// Método que inicia la partida.
    /// </summary>
    public void OnClickBotonIniciarPartida()
    {
        // Se deja de admitir nuevos jugadores en la partida.
        PhotonNetwork.CurrentRoom.IsOpen = false;

        // Ya no se permite que otros vean la partida.
        PhotonNetwork.CurrentRoom.IsVisible = false;

        // Se carga la escena de la partida.
        PhotonNetwork.LoadLevel("Game");
    }

    #endregion

    #region MÉTODOS DE PHOTON

    /// <summary>
    /// Método que se ejecuta cuando se conecta con el Master.
    /// </summary>
    public override void OnConnectedToMaster()
    {
        ActivarPanel(panelMenu.name);
    }

    /// <summary>
    /// Método que se encarga de mantener actualizadas las listas de las partidas y su información.
    /// </summary>
    /// <param name="_roomList">Lista que contiene la información de las partidas.</param>
    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        LimpiarListaPartidas();

        ActualizarCacheListaPartidas(_roomList);
        ActualizarListaPartidas();
    }

    /// <summary>
    /// Método que es invocado cuando el jugador deja el Lobby. Se encarga de limpiar la lista de las partidas.
    /// </summary>
    public override void OnLeftLobby()
    {
        cacheListaPartidas.Clear();

        LimpiarListaPartidas();
    }

    /// <summary>
    /// Método que es invocado cuando ocurre un error al crear una partida.
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        ActivarPanel(panelMenu.name);
    }

    /// <summary>
    /// Método que es invocado cuando no es posible entrar en una partida.
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        ActivarPanel(panelMenu.name);
    }

    /// <summary>
    /// Método que es invocado cuando no es posible unirse a una partida aleatoria.
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string nombrePartida = DatosJugador.Get.Nombre;

        RoomOptions options = new RoomOptions { MaxPlayers = Constantes.MAXIMO_JUGADORES_PARTIDA };

        PhotonNetwork.CreateRoom(nombrePartida, options, null);
    }

    /// <summary>
    /// Método que es invocado cuando se logra entrar en una partida.
    /// </summary>
    public override void OnJoinedRoom()
    {
        ActivarPanel(panelPartida.name);

        // Si no hay una lista de entradas para los jugadores.
        if (entradasListaJugador == null)
        {
            entradasListaJugador = new Dictionary<int, GameObject>();
        }

        // Se revisan los jugadores y se añaden a la lista.
        foreach (Player jugador in PhotonNetwork.PlayerList)
        {
            GameObject nuevaEntrada = Instantiate(prefabEntradaListaJugador);
            nuevaEntrada.transform.SetParent(panelPartida.transform);
            nuevaEntrada.transform.localScale = Vector3.one;
            nuevaEntrada.GetComponent<EntradaListaJugador>().Inicializar(jugador.ActorNumber, jugador.NickName);

            object jugadorListo;
            if (jugador.CustomProperties.TryGetValue(Constantes.JUGADOR_LISTO, out jugadorListo))
            {
                nuevaEntrada.GetComponent<EntradaListaJugador>().JugadorListo((bool)jugadorListo);
            }

            entradasListaJugador.Add(jugador.ActorNumber, nuevaEntrada);
        }

        // Se activa el botón de iniciar partida en función de los jugadores listos.
        botonIniciarJuego.gameObject.SetActive(RevisarJugadoresListos());

        // Se actualizan las propiedades del jugador.
        Hashtable propiedades = new Hashtable
            {
                { Constantes.JUGADOR_NIVEL_CARGADO, false }
            };
        PhotonNetwork.LocalPlayer.SetCustomProperties(propiedades);
    }

    /// <summary>
    /// Método que es invocado cuando se abandona una partida.
    /// </summary>
    public override void OnLeftRoom()
    {
        ActivarPanel(panelMenu.name);

        foreach (GameObject entry in entradasListaJugador.Values)
        {
            Destroy(entry.gameObject);
        }

        entradasListaJugador.Clear();
        entradasListaJugador = null;
    }

    /// <summary>
    /// Método que es invocado cuando un jugador se une a la partida.
    /// </summary>
    /// <param name="_newPlayer">Jugador que se unio a la partida.</param>
    public override void OnPlayerEnteredRoom(Player _newPlayer)
    {
        GameObject nuevaEntrada = Instantiate(prefabEntradaListaJugador);
        nuevaEntrada.transform.SetParent(panelPartida.transform);
        nuevaEntrada.transform.localScale = Vector3.one;
        nuevaEntrada.GetComponent<EntradaListaJugador>().Inicializar(_newPlayer.ActorNumber, _newPlayer.NickName);

        entradasListaJugador.Add(_newPlayer.ActorNumber, nuevaEntrada);

        botonIniciarJuego.gameObject.SetActive(RevisarJugadoresListos());
    }

    /// <summary>
    /// Método que es invocado cuando un jugador abandona la partida.
    /// </summary>
    /// <param name="_otherPlayer"></param>
    public override void OnPlayerLeftRoom(Player _otherPlayer)
    {
        Destroy(entradasListaJugador[_otherPlayer.ActorNumber].gameObject);
        entradasListaJugador.Remove(_otherPlayer.ActorNumber);

        botonIniciarJuego.gameObject.SetActive(RevisarJugadoresListos());
    }

    // Método que es invocado cuando el Master abandona la partida.
    public override void OnMasterClientSwitched(Player _newMasterClient)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == _newMasterClient.ActorNumber)
        {
            botonIniciarJuego.gameObject.SetActive(RevisarJugadoresListos());
        }
    }

    /// <summary>
    /// Método que es llamado cuando se actualizan las propiedades del jugador local.
    /// </summary>
    /// <param name="_jugadorObjetivo">Jugador objetivo.</param>
    /// <param name="_nuevasPorpiedades">Nuevas propiedades</param>
    public override void OnPlayerPropertiesUpdate(Player _jugadorObjetivo, Hashtable _nuevasPorpiedades)
    {
        if (entradasListaJugador == null)
        {
            entradasListaJugador = new Dictionary<int, GameObject>();
        }

        GameObject entrada;
        if (entradasListaJugador.TryGetValue(_jugadorObjetivo.ActorNumber, out entrada))
        {
            object isPlayerReady;
            if (_nuevasPorpiedades.TryGetValue(Constantes.JUGADOR_LISTO, out isPlayerReady))
            {
                entrada.GetComponent<EntradaListaJugador>().JugadorListo((bool)isPlayerReady);
            }
        }

        botonIniciarJuego.gameObject.SetActive(RevisarJugadoresListos());
    }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Método que revisa si los jugadores están listos para iniciar la partida.
    /// </summary>
    /// <returns>Verdadero: Si los jugadores están listos. FALSO: si los jugadores no están listos.</returns>
    private bool RevisarJugadoresListos()
    {
        // Si no somos el host, regresamos el control.
        if (!PhotonNetwork.IsMasterClient) return false;

        // Revisamos si todos los jugadores están listos.
        foreach(Player jugador in PhotonNetwork.PlayerList)
        {
            object jugadorListo;

            if (jugador.CustomProperties.TryGetValue(Constantes.JUGADOR_LISTO, out jugadorListo))
            {
                // Si un jugador no esta listo para la partida, regresamos falso.
                if (!(bool)jugadorListo) return false;

            } 
            // Si no se encuentra un jugador listo.
            else
            {
                return false;
            }
        }

        // Si los jugadores están listos, regresamoes verdadero.
        return true;
    }

    /// <summary>
    /// Método que limpia la lista de partidas.
    /// </summary>
    private void LimpiarListaPartidas()
    {
        foreach(GameObject entrada in entradasListaPartidas.Values)
        {
            Destroy(entrada.gameObject);
        }

        entradasListaPartidas.Clear();
    }

    /// <summary>
    /// Método que activa el botón para iniciar partida si los jugadores están listos.
    /// </summary>
    public void ActualizarPropiedadesDelJugador()
    {
        botonIniciarJuego.gameObject.SetActive(RevisarJugadoresListos());
    }

    /// <summary>
    /// Método que activa o desactiva los paneles.
    /// </summary>
    /// <param name="_nombrePanel">Panel que debe ser activado.</param>
    private void ActivarPanel(string _nombrePanel)
    {
        // Activar el panel conectar
        panelConectar.SetActive(_nombrePanel.Equals(panelConectar.name));

        // Activar el panel de menu.
        panelMenu.SetActive(_nombrePanel.Equals(panelMenu.name));

        // Activar el panel de crear partida.
        //panelCrearPartida.SetActive(_nombrePanel.Equals(panelCrearPartida.name));

        // Activar el panel unirse.
        panelUnirse.SetActive(_nombrePanel.Equals(panelUnirse.name));

        // Activar el panel de listas de partida.
        panelListaPartidas.SetActive(_nombrePanel.Equals(panelListaPartidas.name));

        // Activar el panel de partida.
        panelPartida.SetActive(_nombrePanel.Equals(panelPartida.name));
    }

    /// <summary>
    /// Método que permite actualizar el cache de la lista de partidas.
    /// </summary>
    /// <param name="_listaPartidas">Lista que contiene la info de las partidas.</param>
    private void ActualizarCacheListaPartidas(List<RoomInfo> _listaPartidas)
    {
        foreach(RoomInfo info in _listaPartidas)
        {
            // Remover las partidas de la lista si ya no se puede entrar en ellas.
            if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
            {
                if (cacheListaPartidas.ContainsKey(info.Name))
                {
                    cacheListaPartidas.Remove(info.Name);
                }

                continue;
            }

            // Actualizar la info de la partida.
            if (cacheListaPartidas.ContainsKey(info.Name))
                cacheListaPartidas[info.Name] = info;
            // Se añade la nueva info a la lista.
            else
                cacheListaPartidas.Add(info.Name, info);

        }
    }

    /// <summary>
    /// Método que añade las partidas a la lista de partidas.
    /// </summary>
    private void ActualizarListaPartidas()
    {
        foreach(RoomInfo info in cacheListaPartidas.Values)
        {
            GameObject nuevaEntrada = Instantiate(prefabEntradaListaPartidas);
            nuevaEntrada.transform.SetParent(contenidoListaPartidas.transform);
            nuevaEntrada.transform.localPosition = Vector3.one;
            nuevaEntrada.GetComponent<EntradaListaPartidas>().Inicializar(info.Name, (byte)info.PlayerCount, info.MaxPlayers);

            entradasListaPartidas.Add(info.Name, nuevaEntrada);
        }
    }

    #endregion
}
