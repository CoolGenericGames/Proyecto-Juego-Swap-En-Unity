using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : EnemigoBase
{

    #region Métodos de Unity
    void Start()
    {
        velocidadX = 7f;
        cooldown = 0.15f;

        if(transform.position.x < 0){ direccion = 1f;} //Direccion positiva
        else{direccion = -1f;}  //Direccion negativa

    }

    private void OnEnable()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {

        TimerParaDisparar();

        Move();
        Shoot();

    }
    #endregion

    #region Métodos
    private new void Move() {
        transform.position += new Vector3(direccion * velocidadX * Time.deltaTime, 0, 0);
    }

    private new void Shoot() {
        if (timer > cooldown)
        {
            nuevoProyectil = ObjectsRepository.UseRepository("EnemyBullet", transform.position, Quaternion.identity);
            nuevoProyectil.GetComponent<BalaEnemigo>().ColorBala(esRojo);
            if (!esRojo) nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilAzul;
            else nuevoProyectil.GetComponent<SpriteRenderer>().sprite = spriteProyectilRojo;
            timer = 0f;
        }
    }

    public void ColorEnemigo(int color)
    {
        if(color == ROJO)
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
