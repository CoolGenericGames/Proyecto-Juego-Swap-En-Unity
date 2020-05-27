using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : MonoBehaviour
{
    #region CONSTANTES

    // COLORES ---------------------------------------------------------------------
    /// <summary>
    /// Representa el índice donde se encuentra el rojo.
    /// </summary>
    protected const int ROJO = 0;
    /// <summary>
    /// Representa el índice donde se encuentra el azul.
    /// </summary>
    protected const int AZUL = 1;

    #endregion

    #region VARIABLES

    // MOVIMINTO -------------------------------------------------------------------
    /// <summary>
    /// Velocidad horizontal (X).
    /// </summary>
    public float velocidadX;
    /// <summary>
    /// Velocidad vertical (Y).
    /// </summary>
    public float velocidadY;
    /// <summary>
    /// Dirección a la que se mueve.
    /// </summary>
    public float direccion;


    // TIEMPO ----------------------------------------------------------------------
    /// <summary>
    /// Tiempo que necesita esperar para poder disparar.
    /// </summary>
    protected float tiempoEsperaDisparo;


    // COLOR ------------------------------------------------------------------------
    /// <summary>
    /// Representa el color actual.
    /// </summary>
    protected COLOR_NAVE color;


    // DISPARAR ---------------------------------------------------------------------
    /// <summary>
    /// Permite saber si el enemigo puede disparar o no.
    /// </summary>
    protected bool puedeDisparar;



    // ANTIGUO **********************************************************************
    protected float tiempoRecargaDisparo;
    protected float timer;
    protected bool esRojo;
    // ******************************************************************************

    #endregion

    #region COMPONENTES

    [Header("PROYECTILES")] // ------------------------------------------------------
    /// <summary>
    /// Representa el proyectil que dispara el enemigo.
    /// </summary>
    public GameObject priyectil;

    /// <summary>
    /// Representa el nuevo proyectil que dispara el enemigo.
    /// </summary>
    protected GameObject nuevoProyectil;


    [Header("SPRITES")] // ---------------------------------------------------------
    /// <summary>
    /// Arreglo que contiene las imagenes del enemigo.
    /// </summary>
    public Sprite[] spritesEnemigo;
    /// <summary>
    /// Imagen del proyectil azul.
    /// </summary>
    public Sprite spriteProyectilAzul;
    /// <summary>
    /// Imagen del proyectil rojo.
    /// </summary>
    public Sprite spriteProyectilRojo;

    #endregion

    #region MÉTODOS PUBLICOS

    /// <summary>
    /// Método que se encarga de mover la nave.
    /// </summary>
    public void Mover() { Debug.Log("Mover."); }

    /// <summary>
    /// Método que se encarga de disparar.
    /// </summary>
    public void Disparar() { Debug.Log("Disparar."); }

    /// <summary>
    /// Método que se encarga de manejar el temporizador para disparar.
    /// </summary>
    public void TimerParaDisparar() { timer += Time.deltaTime; }

    /// <summary>
    /// Método que se encarga de reiniciar el temporizador.
    /// </summary>
    public void ResetTimer() { timer = 0; }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Función que permite instanciar una explosión.
    /// </summary>
    /// <param name="_posicion"> Posición de la explosión. </param>
    /// <param name="_objeto"> Objeto que explotó y debe ser regresado al repositorio. </param>
    protected void Explotar(Vector3 _posicion, GameObject _objeto = null)
    {
        // Se crea la exploción.
        ObjectsRepository.UseRepository("Explosion", _posicion, Quaternion.identity);

        // Si hay un objeto.
        if (_objeto)
        {
            // Se regresa el objeto que exploto al repositorio.
            DevolverALaLista(_objeto.gameObject);
        }
    }

    /// <summary>
    /// Método que nos permite devolver a la lista un objeto.
    /// </summary>
    /// <param name="_objeto">El objeto que se va a devolver a la lista.</param>
    protected void DevolverALaLista(GameObject _objeto)
    {
        ObjectsRepository.BackToRepository(_objeto);
    }

    #endregion
}
