using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToQueue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectsRepository.BackToRepository(collision.gameObject);
    }
}
