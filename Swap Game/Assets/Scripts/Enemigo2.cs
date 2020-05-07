using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : Enemigos
{

    #region Métodos de Unity
    void Start()
    {
        velXEnemigo = 13f;
        velYEnemigo = 0f;
        cooldown = 0.15f;

        if (transform.position.x < 0) { direccion = 1f; } //Direccion positiva
        else { direccion = -1f; }  //Direccion negativa
    }

    private void OnEnable()
    {
        ResetTimer();
        velYEnemigo = 0f;
    }
    private void OnDisable()
    {
        ResetTimer();
        velYEnemigo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimerToShoot();
        Move();
        velYEnemigo -= 0.001f;
        Shoot();

    }
    #endregion

    #region Métodos
    private new void Move()
    {
        transform.position += new Vector3(direccion * velXEnemigo * Time.deltaTime, velYEnemigo, 0);
    }

    private new void Shoot()
    {
        if (timer > cooldown)
        {
            nuevabala = ObjectsRepository.UseRepository("EnemyBullet", transform.position, Quaternion.identity);
            nuevabala.GetComponent<BalaEnemigo>().ColorBala(esRojo);
            if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaAzul;
            else nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaRoja;
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