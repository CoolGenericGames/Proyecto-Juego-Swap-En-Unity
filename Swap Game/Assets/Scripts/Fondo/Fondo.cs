using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fondo : MonoBehaviour
{
    #region CONSTANTES

    // VALORES INICIALES -----------------------------------------------------------
    /// <summary>
    /// Representa la velocidad de animación del fondo.
    /// </summary>
    private float VELOCIDAD_ANIMACION = 4f;

    #endregion

    #region VARIABLES

    [Header("ANIMACIÓN")] // -------------------------------------------------------
    /// <summary>
    /// Velocidad con la que se mueve el fondo.
    /// </summary>
    public float velocidadAnimacion;

    // TAMAÑO ----------------------------------------------------------------------
    /// <summary>
    /// Tamaño horizontal (X) de la cámara.
    /// </summary>
    private float camTamX;
    /// <summary>
    /// Tamaño vertical (Y) de la cámara.
    /// </summary>
    private float camTamY;

    #endregion

    #region COMPONENTES

    // CAMARA ----------------------------------------------------------------------
    /// <summary>
    /// Referencia a la camara.
    /// </summary>
    private Camera camara;

    #endregion

    #region MÉTODOS DE UNITY

    // Inicializamos los componentes.
    private void Awake()
    {
        // CAMARA ----------------------------------------------------------------------
        camara = Camera.main;
    }

    // Se inicializan las variables.
    private void Start()
    {
        // ANIMACIÓN -------------------------------------------------------------------
        if (velocidadAnimacion == 0) velocidadAnimacion = VELOCIDAD_ANIMACION;

        // TAMAÑO ----------------------------------------------------------------------
        camTamY = camara.orthographicSize;
        camTamX = camTamY * camara.aspect;
    }

    // Actualizar la lógica del fondo.
    private void Update()
    {
        // Se mueve hacia abajo.
        transform.position += Vector3.down * velocidadAnimacion * Time.deltaTime;
        if (transform.position.y <= -1f) transform.position -= Vector3.down;
    }

    #endregion
}
