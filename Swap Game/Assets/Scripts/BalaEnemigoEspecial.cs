using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigoEspecial : MonoBehaviour
{
    #region Variables
    public float velBala;
    public bool esRoja;

    float ranX;
    float ranY;
    #endregion

    #region Métodos de Unity
    // Start is called before the first frame update
    void Start()
    {
        velBala = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        ranX = Random.Range(-0.05f, 0.05f);
        ranY = Random.Range(-0.05f, 0.1f);
        transform.position -= new Vector3(ranX, ranY + velBala * Time.deltaTime, 0);

    }
    #endregion

    #region Métodos
    public void ColorBala(bool color)
    {
        if (color) esRoja = true;
        else esRoja = false; // es azul
    }
    #endregion
}
