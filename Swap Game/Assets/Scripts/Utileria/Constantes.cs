using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constantes : MonoBehaviour
{
    #region CONSTANTES

    // JUGADOR ---------------------------------------------------------------------
    /// <summary>
    /// Indica el número de vidas que tiene el jugador.
    /// </summary>
    public const int JUGADOR_NUM_VIDAS = 3;
    /// <summary>
    /// Constante que permite saber si el jugador esta listo parala partida.
    /// </summary>
    public const string JUGADOR_LISTO = "JugadorListo";
    /// <summary>
    /// Indica si el jugador esta cargando el nivel.
    /// </summary>
    public const string JUGADOR_NIVEL_CARGADO = "JugadorNivelCargado";
    /// <summary>
    /// indica las vidas del jugador.
    /// </summary>
    public const string JUGADOR_VIDAS = "JugadorVidas";


    // PARTIDA ---------------------------------------------------------------------
    /// <summary>
    /// Número máximo de jugadores por partida.
    /// </summary>
    public const int MAXIMO_JUGADORES_PARTIDA = 2;


    // ETIQUETAS -------------------------------------------------------------------
    /// <summary>
    /// Etiqueta que permite reconocer al enemigo cuadrado.
    /// </summary>
    public const string TAG_ENEMIGO_CUADRADO = "EnemigoCuadrado";
    /// <summary>
    /// Etiqueta que permite reconocer al enemigo triangulo.
    /// </summary>
    public const string TAG_ENEMIGO_TRIANGULO = "EnemigoTriangulo";
    /// <summary>
    /// Etiqueta que permite reconocer al enemigo circulo.
    /// </summary>
    public const string TAG_ENEMIGO_CIRCULO = "EnemigoCirculo";

    /// <summary>
    /// Etiqueta que permite reconocer los proyectiles del enemigo.
    /// </summary>
    public const string TAG_PROYECTIL_ENEMIGO = "ProyectilEnemigo";
    /// <summary>
    /// Etiqueta que permite reconocer los proyectiles de la nave.
    /// </summary>
    public const string TAG_PROYECTIL_NAVE = "Proyectil";


    #endregion

    #region MÉTODOS PUBLICOS

    /// <summary>
    /// Método que pemrite obtener un color.
    /// </summary>
    /// <param name="_indiceColor"></param>
    /// <returns>Un color.</returns>
    public static Color ObtenerColor(int _indiceColor)
    {
        switch (_indiceColor)
        {
            case 0: return Color.red;
            case 1: return Color.green;
            case 2: return Color.blue;
            case 3: return Color.yellow;
            case 4: return Color.cyan;
            case 5: return Color.grey;
            case 6: return Color.magenta;
            case 7: return Color.white;
        }

        return Color.black;
    }

    #endregion
}
