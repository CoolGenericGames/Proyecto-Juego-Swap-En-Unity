using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    const int ROJO = 0;
    const int AZUL = 1;

    public float velXEnemigo;
    public float velYEnemigo;
    public float direccion;
    private float timer;
    private float cooldown;
    private bool esRojo;

    public GameObject BalaEnemigo;
    private GameObject nuevabala;

    public Sprite[] spritesEnemigo;
    public Sprite spriteBala;
    // Start is called before the first frame update
    void Start()
    {
        velXEnemigo = 13f;
        velYEnemigo = 0f;
        cooldown = 0.15f;

        if (transform.position.x < 0) { direccion = 1f; } //Direccion positiva
        else { direccion = -1f; }  //Direccion negativa
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        transform.position += new Vector3(direccion * velXEnemigo * Time.deltaTime, velYEnemigo, 0);
        velYEnemigo -= 0.001f;

        if (esRojo)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[0];
            esRojo = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritesEnemigo[1];
            esRojo = false;
        }


        //Disparo
        if (timer > cooldown)
        {
            nuevabala = Instantiate(BalaEnemigo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            nuevabala.GetComponent<BalaEnemigo>().ColorBala(esRojo);
            if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBala;
            timer = 0f;
        }

        Destroy(gameObject, 3);
    }

    public void ColorEnemigo(int color)
    {
        if (color == ROJO)
        {
            esRojo = true;
        }
        else // Azul
        {
            esRojo = false;
        }
    }
}