using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float randomX;
    private float randomY;
    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public IEnumerator Shaker(float maxtime, float force) {

        float duration = 0;
        while (duration < maxtime)
        {
            transform.position = new Vector3(Random.Range(-force, force), Random.Range(-force, force), transform.position.z);
            duration += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
    }

}
