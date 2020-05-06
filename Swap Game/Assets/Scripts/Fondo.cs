using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fondo : MonoBehaviour
{
    public float velocidad;

    private float xSize;
    private float ySize;
    private Vector3 moverAbajo;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        ySize = cam.orthographicSize;
        xSize = ySize * cam.aspect;
        moverAbajo = new Vector3(0, -1f, 0);
        velocidad = 4;
    }

    // Update is called once per frame
    void Update()
    {
        print(Screen.width);
        transform.position += moverAbajo * velocidad * Time.deltaTime;
        if (transform.position.y <= -1f) {
            transform.position -= moverAbajo;
        }
    }
}
