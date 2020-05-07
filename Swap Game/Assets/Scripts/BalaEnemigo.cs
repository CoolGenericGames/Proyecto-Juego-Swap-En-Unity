using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    #region Varibles
    public float velBala;
    public bool esRoja;
    #endregion

    #region Métodos de Unity
    // Start is called before the first frame update
    void Start()
    {
        velBala = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, velBala * Time.deltaTime, 0);
    }
    #endregion

    #region Métodos
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
    #endregion

}
