using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{

    #region Variables
    public float velBala = 30f;
    public int Puntaje = 1;
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
            ObjectsRepository.UseRepository("Explosion", transform.position, Quaternion.identity);
            ObjectsRepository.BackToRepository(collision.gameObject);
            ObjectsRepository.BackToRepository(gameObject);
            GameController.Score += Puntaje;
        }
		if (collision.CompareTag("EnemigoC"))
        {
            ObjectsRepository.UseRepository("Explosion", transform.position, Quaternion.identity);
            collision.GetComponent<EnemigoC>().CrearBala();
            ObjectsRepository.BackToRepository(collision.gameObject);
            ObjectsRepository.BackToRepository(gameObject);
            GameController.Score += Puntaje;
        }
    }
    #endregion
}
