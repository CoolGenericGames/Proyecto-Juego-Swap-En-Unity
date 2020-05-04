using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velBala;
    public bool esRoja;
   
    // Start is called before the first frame update
    void Start()
    {
        velBala = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, velBala * Time.deltaTime, 0);

        Destroy(gameObject, 3);
    }

    public void ColorBala(bool color)
    {
        if(color)
        {
            esRoja = true;
        }
        else //Azul
        {
            esRoja = false;
        }
    }

}
