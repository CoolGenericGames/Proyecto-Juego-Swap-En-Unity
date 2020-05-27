using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : EnemigoBase
{
    #region CONSTANTES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad inicial en el eje horizontal.
    /// </summary>
    private float VELOCIDAD_INICIAL_X = 13f;
    /// <summary>
    /// Velocidad inicial en el eje horizontal.
    /// </summary>
    private float VELOCIDAD_INICIAL_Y = 0f;

    // TIEMPO ----------------------------------------------------------------------
    /// <summary>
    /// Tiempo que tarda en volver a disparar.
    /// </summary>
    private float TIEMPO_INICIAL_RECARGA_DISPARO = 0.15f;

    #endregion

    #region MÉTODOS DE UNITY

    // se reinicia la velocidad en Y y el temporizador cada vez que el objeto se activa.
    private void OnEnable()
    {
        ResetTimer();
        velocidadY = VELOCIDAD_INICIAL_Y;
    }

    // Inicializamos las variables
    void Start()
    {
        // TIEMPO ----------------------------------------------------------------------
        tiempoRecargaDisparo = TIEMPO_INICIAL_RECARGA_DISPARO;

        // MOVIMIENTO ------------------------------------------------------------------
        velocidadX = VELOCIDAD_INICIAL_X;
        velocidadY = VELOCIDAD_INICIAL_Y;

        direccion = transform.position.x < 0 ? 1f : -1f;
    }

    // Se actualiza la lógica del enemigo.
    void Update()
    {
        TimerParaDisparar();
        Mover();
        Disparar();

    }
    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Método encargado del movimiento del enemigo.
    /// </summary>
    private new void Mover()
    {
        transform.position += new Vector3(direccion * velocidadX * Time.deltaTime, velocidadY, 0);
        velocidadY -= 0.001f;
    }

    /// <summary>
    /// Método encargado de disparar.
    /// </summary>
    private new void Disparar()
    {
        if (timer > tiempoRecargaDisparo)
        {
            nuevoProyectil = ObjectsRepository.UseRepository("EnemyBullet", transform.position, Quaternion.identity);
            nuevoProyectil.GetComponent<BalaEnemigo>().ColorBala(esRojo);
            if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
            else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;
            ResetTimer();
        }
    }

    /// <summary>
    /// Método que se encarga de asignarle un color al enemigo.
    /// </summary>
    /// <param name="_color">Color del enemigo.</param>
    public void ColorEnemigo(int _color)
    {
        if (_color == ROJO)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[ROJO];
            esRojo = true;
            color = COLOR_NAVE.ROJO;
        }
        else // Azul
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[AZUL];
            esRojo = false;
            color = COLOR_NAVE.AZUL;
        }
    }
    #endregion
}