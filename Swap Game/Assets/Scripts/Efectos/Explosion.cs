using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region COMPONENTES

    // CAMARA ----------------------------------------------------------------------
    /// <summary>
    /// Referencia al efecto CameraShake.
    /// </summary>
    CameraShake cameraShake;

    #endregion

    #region MÉTODOS DE UNITY

    // Iniciamos el efecto cuando el objeto se activa.
    private void OnEnable()
    {
        StartCoroutine(cameraShake.Shaker(1f, 0.15f));
    }

    // Inicializamos los componentes
    private void Awake()
    {
        // CAMARA ----------------------------------------------------------------------
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    #endregion

    #region MÉTODOS PRIVADOS

    /// <summary>
    /// Método que permite devolver el objeto a la lista de espera.
    /// </summary>
    public void DevolverALaLista() 
    {
        ObjectsRepository.BackToRepository(gameObject);
    }

    #endregion
}
