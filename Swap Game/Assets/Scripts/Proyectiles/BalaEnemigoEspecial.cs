using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigoEspecial : MonoBehaviour
{
    #region CONSTANTES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad inicial de la nave.
    /// </summary>
    private const float VELOCIDAD_INICIAL = 4f;

    #endregion

    #region VARIABLES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad del proyectil.
    /// </summary>
    public float velocidad;
    /// <summary>
    /// Posición aleatoria del proyectil en X.
    /// </summary>
    private float posicionAleatoriaX;
    /// <summary>
    /// Posición aleatoria del proyectil en Y.
    /// </summary>
    private float posicionAleatoriaY;


    // COLOR -----------------------------------------------------------------------
    /// <summary>
    /// Permite conocer el color del proyectil.
    /// </summary>
    public COLOR_NAVE color;
    /// <summary>
    /// Permite saber si el proyectil es rojo.
    /// </summary>
    public bool esRoja;

    #endregion

    #region Métodos de Unity

    // Se inicializan las variables
    void Start() => velocidad = VELOCIDAD_INICIAL;

    // Se actualiza la lógica del movimiento.
    void Update()
    {
        posicionAleatoriaX = Random.Range(-0.05f, 0.05f);
        posicionAleatoriaY = Random.Range(-0.05f, 0.1f);
        transform.position -= new Vector3(posicionAleatoriaX, posicionAleatoriaY + velocidad * Time.deltaTime, 0);

    }

    #endregion

    #region Métodos

    /// <summary>
    /// Método que se encarga del color del proyectil.
    /// </summary>
    /// <param name="_color"> Color del proyectil. </param>
    public void ColorBala(bool _color)
    {
        if (_color)
        {
            esRoja = true;
            color = COLOR_NAVE.ROJO;
        } 
        else
        {
            esRoja = false;
            color = COLOR_NAVE.AZUL;
        }
    }

    #endregion
}
