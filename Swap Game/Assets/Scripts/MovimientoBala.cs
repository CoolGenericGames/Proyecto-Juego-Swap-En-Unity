using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{

    #region Variables
    public float velBala = 30f;
    public const int puntajeCuadrado = 10;
    public const int puntajeTriangulo = 15;
    public const int puntajeCirculo = 5;
    #endregion

    CameraShake shakeReference;

    #region Métodos de Unity
    void Start()
    {
        shakeReference = GameObject.Find("Camera Origin").transform.Find("Main Camera").GetComponent<CameraShake>();
    }

    void Update()
    {
        transform.position += new Vector3(0, velBala * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
               
        if (collision.CompareTag("Enemigo"))
        {
            ObjectsRepository.UseRepository("Explosion", collision.transform.position, Quaternion.identity);
            GameController.Score += puntajeCuadrado;
            ObjectsRepository.BackToRepository(gameObject);
            ObjectsRepository.BackToRepository(collision.gameObject);
        }
        else if (collision.CompareTag("EnemigoC2"))
        {
            ObjectsRepository.UseRepository("Explosion", collision.transform.position, Quaternion.identity);
            GameController.Score += puntajeTriangulo;
            ObjectsRepository.BackToRepository(gameObject);
            ObjectsRepository.BackToRepository(collision.gameObject);
        }
		else if (collision.CompareTag("EnemigoC"))
        {
            ObjectsRepository.UseRepository("Explosion", collision.transform.position, Quaternion.identity);
            collision.GetComponent<EnemigoC>().CrearBala();
            GameController.Score += puntajeCirculo;
            ObjectsRepository.BackToRepository(gameObject);
            ObjectsRepository.BackToRepository(collision.gameObject);
        }

    }
    #endregion
}
