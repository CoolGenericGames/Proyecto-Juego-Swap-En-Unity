using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{


    public float velBala = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velBala * Time.deltaTime, 0);

        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
		if (collision.CompareTag("EnemigoC"))
        {
            collision.GetComponent<EnemigoC>().CrearBala();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
