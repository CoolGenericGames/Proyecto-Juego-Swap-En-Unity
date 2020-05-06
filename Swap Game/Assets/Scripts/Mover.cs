using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float velocidad;
    Camera cam;
    float xSize;
    float ySize;
    float navexSize;
    float naveySize;

    Vector3 moverX;
    Vector3 moverY;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        ySize = cam.orthographicSize;
        xSize = ySize*4/3;
        navexSize = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        naveySize = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        velocidad = 5f;
        moverX = new Vector3(1f, 0, 0);
        moverY = new Vector3(0, 1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)&&(transform.position.y + naveySize < ySize)) transform.position += moverY * velocidad*Time.deltaTime;

        else if (Input.GetKey(KeyCode.S) && (transform.position.y - naveySize > - ySize)) transform.position += -moverY * velocidad * Time.deltaTime;

        if (Input.GetKey(KeyCode.D) && (transform.position.x + navexSize < xSize)) transform.position += moverX * velocidad * Time.deltaTime;

        else if (Input.GetKey(KeyCode.A) && (transform.position.x - naveySize > -xSize)) transform.position += -moverX * velocidad * Time.deltaTime;
    }
}
