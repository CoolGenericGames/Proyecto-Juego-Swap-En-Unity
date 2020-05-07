using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{

    #region Variables
    public float velBala = 30f;
    #endregion

    #region Métodos de Unity

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velBala * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            ObjectsRepository.BackToRepository(collision.gameObject);
            ObjectsRepository.BackToRepository(gameObject);
        }
		if (collision.CompareTag("EnemigoC"))
        {
            collision.GetComponent<EnemigoC>().CrearBala();
            ObjectsRepository.BackToRepository(collision.gameObject);
            ObjectsRepository.BackToRepository(gameObject);
        }
    }
    #endregion
}
