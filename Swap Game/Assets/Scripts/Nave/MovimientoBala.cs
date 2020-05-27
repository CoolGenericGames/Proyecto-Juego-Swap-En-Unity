﻿using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    #region CONSTANTES

    // PUNTOS ----------------------------------------------------------------------
    /// <summary>
    /// Valor en puntos que tiene el enemigo cuadrado.
    /// </summary>
    private const int PUNTOS_CUADRADO = 10;
    /// <summary>
    /// Valor en puntos que tiene el enemigo triangulo.
    /// </summary>
    private const int PUNTOS_TRIANGULO = 15;
    /// <summary>
    /// Valor en puntos que tiene el enemigo circulo.
    /// </summary>
    private const int PUNTOS_CIRCULO = 5;


    // MOVIMIENTO ------------------------------------------------------------------
    private const float VELOCIDAD_INICIAL = 30f;

    #endregion

    #region VARIABLES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad con la que se mueve el proyectil.
    /// </summary>
    private float velocidad;

    #endregion

    #region COMPONENTES

    // EFECTOS ---------------------------------------------------------------------
    /// <summary>
    /// Referencia al efecto CameraShake.
    /// </summary>
    private CameraShake cameraShake;

    #endregion

    #region MÉTODOS DE UNITY

    // Inicializar componentes.
    private void Awake()
    {
        // EFECTOS ---------------------------------------------------------------------
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    // Inicializamos las variables.
    void Start()
    {
        // MOVIMIENTO ------------------------------------------------------------------
        velocidad = VELOCIDAD_INICIAL;
    }

    // Actualizar la lógica del proyectil (Movimiento).
    void Update()
    {
        transform.position += Vector3.up * velocidad * Time.deltaTime;
    }

    #endregion

    #region MÉTODOS DE COLISIÓN DE UNITY

    private void OnTriggerEnter2D(Collider2D _collider2D)
    {
        // Si el enemigo es un cuadrado. ----------------------------------------------
        if (_collider2D.CompareTag("Enemigo"))
        {
            Explotar(_collider2D.transform.position, _collider2D.gameObject);
            DevolverALaLista(gameObject);

            if (DatosJugador.Get != null) 
                DatosJugador.Get.Puntuacion += PUNTOS_CUADRADO;
        }
        // Si el enemigo es un triángulo. ---------------------------------------------
        else if (_collider2D.CompareTag("EnemigoC2"))
        {
            Explotar(_collider2D.transform.position, _collider2D.gameObject);
            DevolverALaLista(gameObject);

            if (DatosJugador.Get != null)
                DatosJugador.Get.Puntuacion += PUNTOS_TRIANGULO;
        }
        // Si el enemigo es un circulo. -----------------------------------------------
        else if (_collider2D.CompareTag("EnemigoC"))
        {
            _collider2D.GetComponent<EnemigoC>().CrearProyectil();

            Explotar(_collider2D.transform.position, _collider2D.gameObject);
            DevolverALaLista(gameObject);

            if (DatosJugador.Get != null)
                DatosJugador.Get.Puntuacion += PUNTOS_CIRCULO;
        }
    }

    #endregion

    #region MÉTODOS PRIVADOS

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
            DevolverALaLista(_objeto.gameObject);
        }
    }

    /// <summary>
    /// Método que nos permite devolver a la lista un objeto.
    /// </summary>
    /// <param name="_objeto">El objeto que se va a devolver a la lista.</param>
    private void DevolverALaLista(GameObject _objeto)
    {
        ObjectsRepository.BackToRepository(_objeto);
    }

    #endregion
}
