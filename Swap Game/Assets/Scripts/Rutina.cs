using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rutina : MonoBehaviour
{
    #region Constantes
    const int ROJO = 0;
    const int AZUL = 1;
    enum Estados {uno, dos , tres};
    #endregion

    #region Variables

    private float xSize;
    private float ySize;

    private bool ganaste;

    Estados estadoActual;
    #endregion

    #region GameObjects
    public GameObject Enemigo1;
    public GameObject Enemigo2;
    public GameObject EnemigoC;
    private GameObject enemigoInstanciado;
    public GameObject Ganaste;
    public GameObject Perdiste;
    #endregion

    #region Componentes
    private Camera cam;
    #endregion

    #region Métodos de Unity 
    // Start is called before the first frame update
    void Start()
    {
        ganaste = false;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        ySize = cam.orthographicSize;
        xSize = ySize * cam.aspect;
        estadoActual = Estados.uno;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual) {
            case Estados.uno:
                StartCoroutine(RutinaDeEnemigos());
                estadoActual = Estados.dos;
                break;
            case Estados.dos:
                if (ganaste && !Perdiste.activeSelf)
                {
                    StartCoroutine(Victoria());
                    estadoActual = Estados.tres;
                }
                break;
        }
        if (Perdiste.activeSelf) StartCoroutine(Perder());
    }
    #endregion

    #region Métodos

    private IEnumerator Victoria() {
        Ganaste.SetActive(true);
        yield return new WaitForSeconds(3);
        ObjectsRepository.RepositoryObj.Clear();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        yield return null;
    }

    private IEnumerator Perder()
    {
        yield return new WaitForSeconds(4);
        ObjectsRepository.RepositoryObj.Clear();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        yield return null;
    }

    private IEnumerator RutinaDeEnemigos()
    {
        yield return new WaitForSeconds(4);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 5), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 7), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 5), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 7), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(5);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 5), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize, 3), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 3), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 1, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 2 , 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(5);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 4), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 2), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 0), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(3);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 5), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 7), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 5), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize, 3), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 3), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 1, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 2, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize, 3), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 1, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 2, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 4), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 2), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 0), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 1 , 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 1, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 1, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 5), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 4), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 12), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 16), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-10, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-2, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(4, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(8, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(10, ySize + 1), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 4), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 1, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 2, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 3, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(2);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize, 4), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 1, 6), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 2, 8), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize + 3, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-9, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(-3, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(0, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(3, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(6, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(9, ySize), Quaternion.identity);
        enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);
        yield return new WaitForSeconds(1);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize - 2, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(xSize - 2, 10), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 9), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(xSize, 7), Quaternion.identity);
        enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);
        yield return new WaitForSeconds(9);
        ganaste = true;
        yield return null;
    }
    #endregion
}



/*          -------------------------Cuadrado---------------------------------
            enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 3), Quaternion.identity);
            enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(AZUL);

            enemigoInstanciado = ObjectsRepository.UseRepository("SquareEnemy", new Vector2(-xSize, 3), Quaternion.identity);
            enemigoInstanciado.GetComponent<Enemigo1>().ColorEnemigo(ROJO);

            -------------------------Triangulo--------------------------------
            enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 5), Quaternion.identity);Instantiate(Enemigo2, new Vector2(-xSize, 5), Quaternion.identity);
            enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(AZUL);

            enemigoInstanciado = ObjectsRepository.UseRepository("TriangleEnemy", new Vector2(-xSize, 5), Quaternion.identity);Instantiate(Enemigo2, new Vector2(-xSize, 5), Quaternion.identity);
            enemigoInstanciado.GetComponent<Enemigo2>().ColorEnemigo(ROJO);

            --------------------------Circulo--------------------------------------
            enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize + 1), Quaternion.identity);
            enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(AZUL);

            enemigoInstanciado = ObjectsRepository.UseRepository("CircleEnemy", new Vector2(2, ySize + 1), Quaternion.identity);
            enemigoInstanciado.GetComponent<EnemigoC>().ColorEnemigo(ROJO);

     */
