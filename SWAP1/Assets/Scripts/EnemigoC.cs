using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoC : MonoBehaviour
{
	const int ROJO = 0;
    const int AZUL = 1;

	private float timer;
    private float cooldown;
    private bool esRojo;
	public float  velEnemigoC;

	public GameObject BalaEnemigo;
    private GameObject nuevabala;

	public Sprite[] spritesEnemigo;
	public Sprite spriteBala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;

        transform.position += new Vector3(0, velEnemigoC * Time.deltaTime, 0);

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

		Destroy(gameObject, 5);
        
    }
	public void ColorEnemigo(int color)
    {
        if(color == ROJO)
        {
            esRojo = true;
        }
        else // Azul
        {
            esRojo = false;
        }
    }


    public void CrearBala() {
        nuevabala = Instantiate(BalaEnemigo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBala;
        nuevabala = Instantiate(BalaEnemigo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBala;
        nuevabala = Instantiate(BalaEnemigo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBala;
        nuevabala = Instantiate(BalaEnemigo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        nuevabala.GetComponent<BalaEnemigoEspecial>().ColorBala(esRojo);
        if (!esRojo) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBala;
    
    }
	
	
}
