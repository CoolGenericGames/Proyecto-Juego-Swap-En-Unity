using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCirculo : EnemigoBase
{
    #region CONSTANTES

    // MOVIMIENTO ------------------------------------------------------------------
    /// <summary>
    /// Velocidad inicial en el eje horizontal.
    /// </summary>
    private float VELOCIDAD_INICIAL_Y = -5f;

    // PUNTOS ----------------------------------------------------------------------
    /// <summary>
    /// Valor en puntos que tiene el enemigo circulo.
    /// </summary>
    private const int PUNTOS_CIRCULO = 5;

    #endregion

    #region MÉTODOS DE UNITY

    // Se inicializan las variables.
    void Start()
    {
        velocidadY = VELOCIDAD_INICIAL_Y;
    }

    // Se actualiza la lógica del enemigo.
    void Update()
    {
        Mover();
    }

    #endregion

    #region MÉTODO DE COLISIÓN DE UNITY

    private void OnTriggerEnter2D(Collider2D _collider2D)
    {
        // Si colisiona con el proyectil.
        if (_collider2D.CompareTag(Constantes.TAG_PROYECTIL_NAVE))
        {
            // Se crean los proyectiles.
            CrearProyectil();

            // Regresamos el objeto.
            Explotar(gameObject.transform.position, gameObject);

            // Se añanden puntos al jugador.
            if (DatosJugador.Get != null)
                DatosJugador.Get.Puntuacion += PUNTOS_CIRCULO;
        }
    }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Método que se encarga del movimiento del enemigo.
    /// </summary>
    private new void Mover()
    {
        transform.position += new Vector3(0, velocidadY * Time.deltaTime, 0);
    }

    /// <summary>
    /// Método que se encarga del color del enemigo.
    /// </summary>
    /// <param name="_color"></param>
    public void ColorEnemigo(int _color)
    {
        if(_color == ROJO)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[0];
            esRojo = true;
            color = COLOR_NAVE.ROJO;
        }
        else // Azul
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[1];
            esRojo = false;
            color = COLOR_NAVE.AZUL;
        }
    }

    /// <summary>
    /// Método que se encarga de crear los proyectiles.
    /// </summary>
    public void CrearProyectil() 
    {
        nuevoProyectil = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevoProyectil.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);

        if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
        else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;

        nuevoProyectil = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevoProyectil.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);

        if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
        else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;

        nuevoProyectil = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevoProyectil.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);

        if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
        else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;

        nuevoProyectil = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevoProyectil.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);

        if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
        else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;

    }

    #endregion
}
