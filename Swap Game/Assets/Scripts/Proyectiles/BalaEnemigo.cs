using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    #region CONSTANTES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad inicial de la nave.
    /// </summary>
    private const float VELOCIDAD_INICIAL = 15f;

    #endregion

    #region VARIABLES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad del proyectil.
    /// </summary>
    public float velocidad;

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

    // Se inicializan las variables.
    void Start() => velocidad = VELOCIDAD_INICIAL;

    // Se actualiza la lógica. Se mueve el proyectil.
    void Update() => transform.position -= Vector3.up * velocidad * Time.deltaTime;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que se encarga del color del proyectil.
    /// </summary>
    /// <param name="_color"></param>
    public void ColorBala(bool _color)
    {
        if(_color)
        {
            esRoja = true;
            color = COLOR_NAVE.ROJO;
        }
        else //Azul
        {
            esRoja = false;
            color = COLOR_NAVE.AZUL;
        }
    }

    #endregion

}
