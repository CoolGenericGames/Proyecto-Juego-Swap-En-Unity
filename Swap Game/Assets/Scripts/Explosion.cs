using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    CameraShake shakeReference;

    // Start is called before the first frame update
    private void Awake()
    {
        shakeReference = GameObject.Find("Camera Origin").transform.Find("Main Camera").GetComponent<CameraShake>();
    }


    private void OnEnable()
    {
        StartCoroutine(shakeReference.Shaker(1f, 0.15f));
    }

    public void backToTheList() {
        ObjectsRepository.BackToRepository(gameObject);
    }
}
