using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorRutinas : MonoBehaviour
{
    #region ACCIONES Y EVENTOS

    /// <summary>
    /// Evento que es invocado cuando se termina el tiempo.
    /// </summary>
    public static Action evntVictoria;

    #endregion

    #region CONSTANTES

    // COLORES ---------------------------------------------------------------------
    /// <summary>
    /// Representa el índice que corresponde al color rojo.
    /// </summary>
    private const int ROJO = 0;
    /// <summary>
    /// Representa el índice que corresponde al color rojo.
    /// </summary>
    private const int AZUL = 1;

    #endregion

    #region VARIABLES

    // TAMAÑO ----------------------------------------------------------------------
    /// <summary>
    /// Representa el tamaño horizontal de la cámara.
    /// </summary>
    private float camTamX;
    /// <summary>
    /// Representa el tamaño vertical de la cámara.
    /// </summary>
    private float camTamY;

    // AUXILIAR ----------------------------------------------------------------------
    /// <summary>
    /// Variable auxiliar que permite manipula multiples enemigos del repositorio.
    /// </summary>
    private GameObject enemigoInstanciado;

    #endregion

    #region COMPONENTES

    [Header("OBJETOS INSTANCIABLES")] // -------------------------------------------
    /// <summary>
    /// Referencia al enemigo cuadrado.
    /// </summary>
    public GameObject Enemigo1;
    /// <summary>
    /// Referencia al enemigo triángulo.
    /// </summary>
    public GameObject Enemigo2;
    /// <summary>
    /// Referencia al enemigo circulo.
    /// </summary>
    public GameObject EnemigoC;

    // CÁMARA ----------------------------------------------------------------------
    private Camera camara;

    #endregion

    #region IEnumerator
    /// <summary>
    /// Variable que guarda corrutina.
    /// </summary>
    private IEnumerator corrutina;
    #endregion

    #region MÉTODOS UNITY

    // Suscribimos los métodos a los eventos pertinentes.
    private void OnEnable()
    {
        ControladorNave.evntVida += VerficarDerrota;
    }

    // Se desuscriben todos los métodos de sus eventos.
    private void OnDisable()
    {
        ControladorNave.evntVida -= VerficarDerrota;
    }

    // Inicializamos los componentes.
    private void Awake()
    {
        // CÁMARA ----------------------------------------------------------------------
        camara = Camera.main;
    }

    // Inicializamos las variables.
    private void Start()
    {
        // TAMAÑO ----------------------------------------------------------------------
        camTamY = camara.orthographicSize;
        camTamX = camTamY * camara.aspect;

        // -----------------------------------------------------------------------------
        corrutina = RutinaEnemigos();
        StartCoroutine(corrutina);
    }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Rutina que se ejecuta una vez el jugador gana el juego.
    /// </summary>
    /// <returns></returns>
    private void Victoria()
    {
        // Se limpia el repositorio.
        ObjectsRepository.RepositoryObj.Clear();

        // Se invoca el evento de victoria.
        evntVictoria?.Invoke();
    }

    private void VerficarDerrota(int _vidas)
    {
        // Si el jugador se quedo sin vidas.
        if (_vidas < 0)
        {
            // Se detiene la rutina de los enemigos.
            StopCoroutine(corrutina);

            // Se limpia el repositorio.           
        }
    }

    #endregion

    #region RUTINAS

    /// <summary>
    /// Rutina que se encarga de hacer aparecer a los enemigos en sus respectivos lugares en el momento indicado.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RutinaEnemigos()
    {
        // Inicia la lógica de los enemigos.

        yield return new WaitForSeconds(4);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 14), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 14), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 14), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 12), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 12), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-11, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-7, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-5, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-1, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(1, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(5, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(7, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(11, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX - 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX - 4, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX - 6, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX - 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX - 4, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX - 6, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX + 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX + 4, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX + 6, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX + 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX + 4, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX + 6, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 12), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-11, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-7, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(7, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(11, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-11, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-7, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(7, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(11, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(3);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 13), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 13), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 11), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 11), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-11, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-7, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-5, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-1, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(1, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(5, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(7, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(11, camTamY + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(4);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 14), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 12), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 4), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);




        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);





        yield return new WaitForSeconds(5);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX - 1, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX + 1, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX - 2, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX + 2, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX - 3, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX + 3, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX - 1, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX + 1, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX - 2, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX + 2, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-13, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-camTamX - 3, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(camTamX + 3, 15), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-12, camTamY), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(camTamX, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);

        yield return new WaitForSeconds(9);

        // Si llego hasta este punto, el jugador termino la partida.
        Victoria();

        // Se termina la rutina.
        yield return null;
    }

    #endregion
}
