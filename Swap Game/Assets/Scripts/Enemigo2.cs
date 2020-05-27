using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : EnemigoBase
{

    #region Métodos de Unity
    void Start()
    {
        velocidadX = 13f;
        velocidadY = 0f;
        cooldown = 0.15f;

        if (transform.position.x < 0) { direccion = 1f; } //Direccion positiva
        else { direccion = -1f; }  //Direccion negativa
    }

    private void OnEnable()
    {
        ResetTimer();
        velocidadY = 0f;
    }
    private void OnDisable()
    {
        ResetTimer();
        velocidadY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimerParaDisparar();
        Move();
        velocidadY -= 0.001f;
        Shoot();

    }
    #endregion

    #region Métodos
    private new void Move()
    {
        transform.position += new Vector3(direccion * velocidadX * Time.deltaTime, velocidadY, 0);
    }

    private new void Shoot()
    {
        if (timer > cooldown)
        {
            nuevoProyectil = ObjectsRepository.UseRepository("EnemyBullet", transform.position, Quaternion.identity);
            nuevoProyectil.GetComponent<BalaEnemigo>().ColorBala(esRojo);
            if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
            else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;
            ResetTimer();
        }
    }

    public void ColorEnemigo(int color)
    {
        if (color == ROJO)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[0];
            esRojo = true;
        }
        else // Azul
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[1];
            esRojo = false;
        }
    }
    #endregion
}