using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Enumeración que contiene todos los colores que puede tener la nave.
/// </summary>
public enum COLOR_NAVE
{
    AZUL,
    ROJO
}

public class ControladorNave : MonoBehaviour
{
    #region ACCIONES Y EVENTOS

    /// <summary>
    /// Evento que es invocado cuando se actualizan las vidas de la nave.
    /// </summary>
    public static Action<int> evntVida;

    /// <summary>
    /// Eveento que es invocado cuando se le asigna un nombre a la nave.
    /// </summary>
    public static Action<string> evntNombre;

    /// <summary>
    /// Evento que es invocado cuando ocurre un error con el Input.
    /// </summary>
    public static Action<string, bool> evntMensajeInput;

    #endregion

    #region CONSTANTES

    // INFORMACION -----------------------------------------------------------------
    /// <summary>
    /// Número inicial de vidas.
    /// </summary>
    private const int NUM_VIDAS = 3;
    /// <summary>
    /// Sirve para saver si ocurrio un error con el dispositivo de entrada. 
    /// </summary>
    private const bool ES_ERROR = true;


    // SPRITES ---------------------------------------------------------------------
    /// <summary>
    /// Representa el índice donde se encuentra la imagen de la nave azul.
    /// </summary>
    private const int SPRITE_NAVE_AZUL = 0;
    /// <summary>
    /// Representa el índice donde se encuentra la imagen de la nave roja.
    /// </summary>
    private const int SPRITE_NAVE_ROJA = 1;


    // DIRECCIONES -----------------------------------------------------------------
    /// <summary>
    /// COnstante que representa la dirección Y positiva.
    /// </summary>
    private const int ARRIBA = 1;
    /// <summary>
    /// COnstante que representa la dirección Y negativa.
    /// </summary>
    private const int ABAJO = -1;
    /// <summary>
    /// COnstante que representa la dirección X positiva.
    /// </summary>
    private const int DERECHA = 1;
    /// <summary>
    /// COnstante que representa la dirección X negativa.
    /// </summary>
    private const int IZQUIERDA = -1;


    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad inicial de la nave.
    /// </summary>
    private const float VELOCIDAD_INICIAL = 8f;


    // COLOR ------------------------------------------------------------------------
    /// <summary>
    /// Valor del alfa de la imagen cuando la nave e sinvencible.
    /// </summary>
    private const float ALFA_INVENCIBILIDAD = 0.2f;
    /// <summary>
    /// Valor del alfa normal de la nave..
    /// </summary>
    private const float ALFA_NORMAL = 1f;


    // TIEMPO -----------------------------------------------------------------------
    /// <summary>
    /// Tiempo que debe pasar entre los disparos.
    /// </summary>
    private const float TIEMPO_ENTRE_DISPAROS = 0.1f;
    /// <summary>
    /// Tiempo que dura la invencibilidad.
    /// </summary>
    private const float TIEMPO_DE_INVENCIBILIDAD = 2f;

    #endregion

    #region VARIABLES

    // TAMAÑO ----------------------------------------------------------------------
    /// <summary>
    /// Tamaño horizontal (X) de la cámara.
    /// </summary>
    private float camTamX;
    /// <summary>
    /// Tamaño vertical (Y) de la cámara.
    /// </summary>
    private float camTamY;
    /// <summary>
    /// Tamaño horizontal (X) de la nave.
    private float naveTamX;
    /// </summary>
    /// <summary>
    /// Tamaño vertical (Ys) de la nave.
    /// </summary>
    private float naveTamY;


    // DATOS -----------------------------------------------------------------------
    /// <summary>
    /// Cantidad de vidas que tiene la nave.
    /// </summary>
    private int vidas;

    /// <summary>
    /// Color actual de la nave.
    /// </summary>
    private COLOR_NAVE color;

    /// <summary>
    /// Nombre de la nave.
    /// </summary>
    private string nombre;


    // MOVIMIENTO -------------------------------------------------------------------
    /// <summary>
    /// Representa la dirección del movimiento.
    /// </summary>
    private Vector2 direccion;
    /// <summary>
    /// Velocidad de movimiento de la nave.
    /// </summary>
    private float velocidad;


    // INVENCIBILIDAD ---------------------------------------------------------------
    /// <summary>
    /// Permite saber si la nave es o no invencible.
    /// </summary>
    private bool esInvencible;



    [Header("DISPARAR")] // --------------------------------------------------------
    /// <summary>
    /// Referencia al proyectil que dispara la nave.
    /// </summary>
    public GameObject proyectil;

    /// <summary>
    /// Referencia al proyectil que dispara la nave.
    /// </summary>
    private GameObject nuevoProyectil;

    /// <summary>
    /// Permite saber si la nave puede disparar o no.
    /// </summary>
    private bool puedeDisparar;


    #endregion

    #region COMPONENTES

    // CAMARA ----------------------------------------------------------------------
    /// <summary>
    /// Referencia a la camara.
    /// </summary>
    private Camera camara;


    // INVENCIVILIDAD --------------------------------------------------------------
    /// <summary>
    /// Color que se utilizará cuando la nave sea invencible.
    /// </summary>
    private Color colorActualSprite;


    // COLISIÓN --------------------------------------------------------------------
    /// <summary>
    /// Referencia al Collider2D que sirve como hitbox.
    /// </summary>
    private Collider2D hitbox;


    [Header("SPRITES")] // ---------------------------------------------------------
    /// <summary>
    /// Arreglo que contiene las imagenes de la nave.
    /// </summary>
    public Sprite[] spritesNave;
    /// <summary>
    /// Imagen del proyectil azul.
    /// </summary>
    public Sprite spriteProyectilAzul;
    /// <summary>
    /// Imagen del proyectil rojo.
    /// </summary>
    public Sprite spriteProyectilRojo;


    #endregion

    #region MÉTODOS DE UNITY

    // Se suscriben a los eventos.
    private void OnEnable()
    {
        ControladorRutinas.evntVictoria += Desactivar;
    }

    // Se desuscriben a los eventos.
    private void OnDisable()
    {
        ControladorRutinas.evntVictoria -= Desactivar;
    }

    // Se inicializan los componentes.
    private void Awake()
    {
        // CAMARA ----------------------------------------------------------------------
        camara = Camera.main;

        // INVENCIVILIDAD --------------------------------------------------------------
        colorActualSprite = GetComponent<SpriteRenderer>().color;

        // COLISIÓN --------------------------------------------------------------------
        hitbox = GetComponent<Collider2D>();
    }

    // Se inicializan las variables.
    private void Start()
    {
        // TAMAÑO ----------------------------------------------------------------------
        camTamX = camara.orthographicSize * camara.aspect;
        camTamY = camara.orthographicSize;

        naveTamX = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        naveTamY = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        // DATOS -----------------------------------------------------------------------
        vidas = NUM_VIDAS;
        color = COLOR_NAVE.ROJO;

        // Se invoca el evento que informa de las vidas.
        evntVida?.Invoke(vidas);

        // Se invoca el evento que informa del nombre.
        if (DatosJugador.Get != null)
        {
            nombre = DatosJugador.Get.Nombre;
            evntNombre?.Invoke(nombre);
        }

        // MOVIMIENTO ------------------------------------------------------------------
        velocidad = VELOCIDAD_INICIAL;

        // INVENCIBILIDAD ---------------------------------------------------------------
        esInvencible = false;

        // DISPARAR --------------------------------------------------------------------
        puedeDisparar = true;
    }

    // Se actualiza la lógica del juego.
    private void Update()
    {
        Mover();
    }

    #endregion

    #region MÉTODOS DE COLISIÓN DE UNITY

    private void OnTriggerEnter2D(Collider2D _collider2D)
    {
        if (esInvencible == false)
        {
            // Si la nave colisiona directamente contra un enemigo.
            if (_collider2D.CompareTag("Enemigo") || _collider2D.CompareTag("EnemigoC") || _collider2D.CompareTag("EnemigoC2"))
            {
                Explotar(_collider2D.transform.position, _collider2D.gameObject);
                Explotar(transform.position);

                StartCoroutine(RutinaInvencible());
                vidas--;
            } 
            // Si colisiona con un proyectil enemigo.
            else if (_collider2D.CompareTag("BalaEnemigo"))
            {
                // Si es un proyectil normal.
                if (_collider2D.gameObject.GetComponent<BalaEnemigo>() != null)
                {
                    BalaEnemigo balaEnemigo = _collider2D.gameObject.GetComponent<BalaEnemigo>();

                    // Si el color de la nave es igual al color del proyectil.
                    if (balaEnemigo.color != this.color)
                    {
                        Explotar(transform.position, _collider2D.gameObject);
                        StartCoroutine(RutinaInvencible());

                        vidas--;
                    }
                    // Si el proyectil corresponde al color de la nave, sube la puntuación y se elimina el proyectil.
                    else
                    {
                        if (DatosJugador.Get != null) DatosJugador.Get.Puntuacion++;
                        ObjectsRepository.BackToRepository(_collider2D.gameObject);
                    }
                }
                // Si es un proyectil especial
                else
                {
                    BalaEnemigoEspecial balaEnemigoEspecial = _collider2D.gameObject.GetComponent<BalaEnemigoEspecial>();


                    // Si el color de la nave es igual al color del proyectil.
                    if (balaEnemigoEspecial.color != this.color)
                    {
                        Explotar(transform.position, _collider2D.gameObject);
                        StartCoroutine(RutinaInvencible());

                        vidas--;
                    }
                    // Si el color del proyectil corresponde al de la nave, sube la puntuación y se elimina el proyectil.
                    else
                    {
                        if (DatosJugador.Get != null) DatosJugador.Get.Puntuacion++;
                        ObjectsRepository.BackToRepository(_collider2D.gameObject);
                    }
                }
            }

            // Revisar las vidas.
            evntVida?.Invoke(vidas);
            if (vidas < 0) Desactivar();
        }
    }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Método encargado de todo lo referente al movimiento.
    /// </summary>
    private void Mover() 
    {
        // Referencia a las posiciones X,Y de la nave.
        float posicionY = transform.position.y;
        float posicionX = transform.position.x;

        // MOVIMIENTO VERTICAL ---------------------------------------------------------
        if (direccion.y == ARRIBA && (posicionY + naveTamY < camTamY))
            transform.position += Vector3.up * velocidad * Time.deltaTime;

        else if (direccion.y == ABAJO && (posicionY - naveTamY > -camTamY))
            transform.position += Vector3.down * velocidad * Time.deltaTime;


        // MOVIMIENTO HORIZONTAL -------------------------------------------------------
        if (direccion.x == DERECHA && (posicionX + naveTamX < camTamX))
            transform.position += Vector3.right * velocidad * Time.deltaTime;

        else if (direccion.x == IZQUIERDA && (posicionX - naveTamX > -camTamX))
            transform.position += Vector3.left * velocidad * Time.deltaTime;
    }

    /// <summary>
    /// Función que permite instanciar una explosión.
    /// </summary>
    /// <param name="_posicion"> Posición de la explosión. </param>
    /// <param name="_objeto"> Objeto que explotó y debe ser regresado al repositorio. </param>
    private void Explotar(Vector3 _posicion, GameObject _objeto = null)
    {
        // Se crea la exploción.
        ObjectsRepository.UseRepository("Explosion", _posicion, Quaternion.identity);

        // Si hay un objeto.
        if (_objeto)
        {
            // Se regresa el objeto que exploto al repositorio.
            ObjectsRepository.BackToRepository(_objeto.gameObject);
        }
    }

    /// <summary>
    /// Permite desactivar la nave cuando se acabo el tiempo o las vidas.
    /// </summary>
    private void Desactivar()
    {
        gameObject.SetActive(false);
    }

    #endregion

    #region RUTINAS

    /// <summary>
    /// Rutina que controla la realización del disparo.
    /// </summary>
    /// <returns></returns>
    IEnumerator RutinaDisparar()
    {
        // Se evitan multiples llamadas de la rutina.
        puedeDisparar = false;

        // Se realiza el disparo.
        nuevoProyectil = ObjectsRepository.UseRepository(
            "Bullet",
            new Vector2(transform.position.x, transform.position.y + naveTamY + 0.3f),
            Quaternion.identity) as GameObject;

        if (color == COLOR_NAVE.AZUL) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
        else if (color == COLOR_NAVE.ROJO) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;

        // Se reproduce el sonido.
        GetComponent<AudioSource>().Play();

        // Se espara para poder realizar otro disparo.
        yield return new WaitForSeconds(TIEMPO_ENTRE_DISPAROS);

        // Se habilita el poder disparar otra vez.
        puedeDisparar = true;
    }

    /// <summary>
    /// Rutina que 
    /// </summary>
    /// <returns></returns>
    IEnumerator RutinaInvencible()
    {
        // Evitamos múltiples llamadas a la rutina.
        esInvencible = true;

        // Desactivamos la hitbox.
        hitbox.enabled = false;

        // Se actualiza alfa del color.
        colorActualSprite.a = ALFA_INVENCIBILIDAD;
        GetComponent<SpriteRenderer>().color = colorActualSprite;

        // Se espera a que termine la invencibilidad.
        yield return new WaitForSeconds(TIEMPO_DE_INVENCIBILIDAD);

        // Se actualiza alfa del color.
        colorActualSprite.a = ALFA_NORMAL;
        GetComponent<SpriteRenderer>().color = colorActualSprite;

        // Se restaura la hitbox.
        hitbox.enabled = true;

        // Se permiten las llamadas a la rutina.
        esInvencible = false;
    }

    #endregion

    #region INPUT SYSTEM

    // MÉTODOS DEFAULT -------------------------------------------------------------
    /// <summary>
    /// Método que es invocado cuando se pierde el dispositivo de entrada.
    /// </summary>
    private void OnDeviceLost() { evntMensajeInput?.Invoke("[!] ERROR: NO SE DETECATA NINGUN DISPOSITIVO DE ENTRADA.", ES_ERROR); }

    /// <summary>
    /// Método que es invocado cuando se reconecta el dispositivo de entrada,
    /// </summary>
    private void OnDeviceRegained() { evntMensajeInput?.Invoke("[!] SE RECONECTO EL DISPOSITIVO DE ENTRADA.", !ES_ERROR); }

    /// <summary>
    /// Método que es invocado cuando los controles (input) cambian.
    /// </summary>
    private void OnControlsChanged() { evntMensajeInput?.Invoke("[!] SE CAMBIO EL DISPOSITIVO DE ENTRADA.", !ES_ERROR); }


    // MÉTOODS PROPIOS -------------------------------------------------------------
    /// <summary>
    /// Método que asigna el valor del input.
    /// </summary>
    /// <param name="_inputValue"> Información acerca de los valores de entrada. </param>
    private void OnMover(InputValue _inputValue)
    {
        direccion = _inputValue.Get<Vector2>();
        direccion.x = Mathf.RoundToInt(direccion.x);
        direccion.y = Mathf.RoundToInt(direccion.y);
    }

    /// <summary>
    /// Método que controla el disparo de la nave.
    /// </summary>
    private void OnDisparar() { if (puedeDisparar) StartCoroutine(RutinaDisparar()); }

    /// <summary>
    /// Método que se encarga de cambiar el color de la nave.
    /// </summary>
    private void OnCambiarColor()
    {
        if (color == COLOR_NAVE.ROJO)
        {
            GetComponent<SpriteRenderer>().sprite = spritesNave[SPRITE_NAVE_AZUL];
            color = COLOR_NAVE.AZUL;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = spritesNave[SPRITE_NAVE_ROJA];
            color = COLOR_NAVE.ROJO;
        }
    }

    #endregion
}
