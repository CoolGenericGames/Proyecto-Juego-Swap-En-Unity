using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoC : Enemigos
{

    #region Métodos de Unity
    // Start is called before the first frame update
    void Start()
    {
        velYEnemigo = -5;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
    }
    #endregion

    #region Métodos
    private new void Move()
    {
        transform.position += new Vector3(0, velYEnemigo * Time.deltaTime, 0);
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
    public void CrearBala() {
        nuevabala = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaAzul;
        else nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaRoja;
        nuevabala = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaAzul;
        else nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaRoja;
        nuevabala = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaAzul;
        else nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaRoja;
        nuevabala = ObjectsRepository.UseRepository("SpecialBullet", transform.position, Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaAzul;
        else nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaRoja;

    }
    #endregion
}
