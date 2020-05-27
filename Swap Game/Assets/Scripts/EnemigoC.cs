using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoC : EnemigoBase
{

    #region Métodos de Unity
    // Start is called before the first frame update
    void Start()
    {
        velocidadY = -5;
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
        transform.position += new Vector3(0, velocidadY * Time.deltaTime, 0);
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
