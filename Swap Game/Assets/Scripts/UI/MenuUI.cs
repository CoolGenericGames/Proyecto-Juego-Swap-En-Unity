using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    #region CONSTANTES

    // TIEMPO ----------------------------------------------------------------------
    private float TIEMPO_ESPERA_ANIM = 4f;

    #endregion

    #region VARIABLES

    // ANIMACIÓN -------------------------------------------------------------------
    /// <summary>
    /// Representa el bucle de la animación del titulo.
    /// </summary>
    private bool bucleAnim;

    // COLOR -----------------------------------------------------------------------
    /// <summary>
    /// Representa el color rojo.
    /// </summary>
    private Color colorAzul;
    /// <summary>
    /// Representa el color rojo claro.
    /// </summary>
    private Color colorAzulClaro;
    /// <summary>
    /// Representa el color azul.
    /// </summary>
    private Color colorRojo;
    /// <summary>
    /// Representa el color azul claro.
    /// </summary>
    private Color ColorRojoClaro;

    #endregion

    #region COMPONENTES

    [Header("IMAGENES")] // --------------------------------------------------------
    /// <summary>
    /// Representa el logo del juego en el menú de inicio.
    /// </summary>
    public Image imagenLogo;

    [Header("TEXTO")] // -----------------------------------------------------------
    /// <summary>
    /// Representa el campo de texto que muestra el titulo del juego.
    /// </summary>
    public Text textoTitulo;


    #endregion

    #region MÉTODOS DE UNITY

    // Inicializamos las variables.
    private void Start()
    {
        // ANIMACIÓN -------------------------------------------------------------------
        bucleAnim = false;

        // COLOR -----------------------------------------------------------------------
        colorAzulClaro = new Color(50f / 255f, 172f / 255f, 1f);
        colorAzul      = new Color(158f / 255f, 229f / 255f, 1f);
        colorRojo      = new Color(1f, 52 / 255f, 50 / 255f);
        ColorRojoClaro = new Color(1f, 158f / 255f, 161f / 255f);


        StartCoroutine(AnimarMenu());
    }

    // Actualizar la lógica del menu.
    private void Update()
    {
        if (bucleAnim == false)
            StartCoroutine(AnimarMenu());
    }

    #endregion

    #region MÉTODOS PUBLICOS

    /// <summary>
    /// Método que permite ir a la escena de juego.
    /// </summary>
    public void Jugar() => OnJugar();

    /// <summary>
    /// Método que permite cerrar el juego.
    /// </summary>
    public void Salir() => OnSalir();

    #endregion

    #region RUTINAS

    // Rutina encargada de animar el menu principal.
    IEnumerator AnimarMenu()
    {
        // Evitamos múltiples llamadas a la rutina.
        bucleAnim = true;

        // Cambiamos los colores.
        textoTitulo.color = colorAzul;
        imagenLogo.color  = colorAzulClaro;

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(TIEMPO_ESPERA_ANIM);

        textoTitulo.color = colorRojo;
        imagenLogo.color  = ColorRojoClaro;

        yield return new WaitForSeconds(TIEMPO_ESPERA_ANIM);

        // Permitimos que el bucle vuelva a iniciar.
        bucleAnim = false;
    }

    #endregion

    #region INPUT SYSTEM

    /// <summary>
    /// Método que permite cerrar el juego.
    /// </summary>
    private void OnSalir() => Application.Quit();

    /// <summary>
    /// Método que permite ir a la escena de juego.
    /// </summary>
    private void OnJugar() => SceneManager.LoadScene("Game", LoadSceneMode.Single);

    #endregion
}
