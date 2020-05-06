using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region Variables

    private bool loop;

    #endregion
    #region Componentes
        public Image Imagen;

        public Text titulo;
    #endregion


    #region Métodos de Unity
    void Start()
    {
        loop = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))salir();
        else if (Input.GetKeyDown(KeyCode.Return)) jugar();
        if (!loop)
        {
            loop = true;
            StartCoroutine(EjecucionTitulo());
        }
    }
    #endregion

    #region Métodos
    public void jugar(){
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

	public void salir(){
		Application.Quit();
	}

    private IEnumerator EjecucionTitulo() {
        titulo.color = new Color(50f / 255f, 172f / 255f, 255f / 255f);
        Imagen.color = new Color(158f / 255f, 229f / 255f, 255f / 255f);
        yield return new WaitForSeconds(4);
        titulo.color = new Color(255 / 255f, 52 / 255f, 50 / 255f);
        Imagen.color = new Color(255f / 255f, 158f / 255f, 161f / 255f);
        yield return new WaitForSeconds(4);
        loop = false;
        yield return null;
    }
    #endregion
}
