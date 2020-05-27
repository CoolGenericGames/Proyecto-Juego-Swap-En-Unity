using System;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayFabFormularioLogin : MonoBehaviour
{
    #region ACCIONES Y EVENTOS

    /// <summary>
    /// Action that is invoked when all user data is obtained.
    /// </summary>
    public static Action evntAutentificado;
    
    #endregion

    #region VARIABLES

    /// <summary>
    /// Representa el nombre que usará el usuario en el juego.
    /// </summary>
    private string _username;
    
    /// <summary>
    /// Correo electronico del usuario. Se requiere para iniciar sesión.
    /// </summary>
    private string _userEmail;
    
    /// <summary>
    /// Contraseña que usa el usuario para iniciar sesión.
    /// </summary>
    private string _userPassword;

    /// <summary>
    /// Permite saber si el usuario esta o no, en el formulario de inicio de seción.
    /// </summary>
    private bool _estaIniciandoSesion;

    #endregion
    
    #region COMPONENTES PUBLICOS DEL UI

    [Header("TEXTOS DE TextMeshPro")] // ----------------------------------------------
    /// <summary>
    /// Referencia al campo de texto donde se mostrará el titulo.
    /// </summary>
    public TextMeshProUGUI textoTitulo;
    /// <summary>
    /// Referencia al campo de texto del botón conectar.
    /// </summary>
    public TextMeshProUGUI textoBotonConectar;
    /// <summary>
    /// Referencia al campo de texto del botón que permite cambiar entre formularios.
    /// El formulario de registro y el formulario de inicio de sesión.
    /// </summary>
    public TextMeshProUGUI textoBotonCambiarFormulario;
    /// <summary>
    /// Referencia al campo de texto que mostrará información acerca del estado de la conección.
    /// </summary>
    public TextMeshProUGUI textoDeEstado;


    [Header("TEXTO DE LOS INPUTFIELDS")] // ------------------------------------------
    /// <summary>
    /// Representa el campo de texto de donde se obtendrá el nombre de usuario.
    /// </summary>
    public Text textoNombreUsuario;
    /// <summary>
    /// Representa el campo de texto de donde se obtendrá el correo del usuario.
    /// </summary>
    public Text textoCorreoUsuario;
    /// <summary>
    /// Representa el campo de texto de donde se obtendrá la contraseña del usuario.
    /// </summary>
    public Text textoContraUsuario;


    [Header("OBJETOS UI")] // --------------------------------------------------------
    /// <summary>
    /// Reference to the InputField game object that captures the username.
    /// </summary>
    public GameObject UsernameInputField;

    #endregion PUBLIC UI COMPONENTS
    
    #region MÉTODOS DE UNITY

    private void Start()
    {
        // Se asigna el ID del titulo a la configuración de PlayFab.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
            PlayFabSettings.TitleId = "9CC1F";
        
        // Se inicializa el formulario de inicio de sesión.
        InicializarFormularioInicioSesion();
    }

    #endregion

    #region MÉTODOS PARA EL INICIO DE SESIÓN

    /// <summary>
    /// Método que le permite al usuario iniciar sesión.
    /// </summary>
    private void IniciarSesion()
    {
        var request = new LoginWithEmailAddressRequest() { Email = _userEmail, Password = _userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, InicioDeSesionExitoso, InicioDeSesionFallido);
    }

    /// <summary>
    /// Método que es invocado cuando el usuario inicio sesión con éxito.
    /// </summary>
    /// <param name="_resultado">Información acerca del inicio de sesión.</param>
    private void InicioDeSesionExitoso(LoginResult _resultado)
    {
        Debug.Log("Inicio de sesión exitoso.");
        
        // Inicializar los datos del jjugador.
        GetPlayFabPlayerData(_resultado.PlayFabId);

        // desactivar este objeto.
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Method that is invoked when the user fails to log in successfully.
    /// </summary>
    /// <param name="_error">Información acerca del error de inicio de sesión.</param>
    private void InicioDeSesionFallido(PlayFabError _error)
    {
        textoDeEstado.text = "Estado: Error al iniciar sesión | " + _error.GenerateErrorReport();
    }

    #endregion

    #region MÉTODOS PARA EL REGISTRO DE USUARIOS

    /// <summary>
    /// Método que permite registrar un nuevo usuario.
    /// </summary>
    private void RegistrarUsuario()
    {
        if (!string.IsNullOrEmpty(_userEmail))
            _userEmail = _userEmail.ToLower();

        var request = new RegisterPlayFabUserRequest()
        {
            Email       = _userEmail,
            Password    = _userPassword,
            Username    = _username,
            DisplayName = _username
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegistroDeUsuarioExitoso, OnRegisterUserFailure);
    }
    
    /// <summary>
    /// Método que es invocado cuando se registra un nuevo usuario con éxito.
    /// </summary>
    /// <param name="_resultado">Información del registro.</param>
    private void RegistroDeUsuarioExitoso(RegisterPlayFabUserResult _resultado)
    {
        Debug.Log("Nuevo usuario registrado.");
        
        textoDeEstado.text = "Estado: Nuevo usuario registrado.";

        IniciarSesion();
    }

    /// <summary>
    /// Método que es invocadoc cuando ocurre un error al registrar un usuario.
    /// </summary>
    /// <param name="_error">Información acerca del error.</param>
    private void OnRegisterUserFailure(PlayFabError _error)
    {
        textoDeEstado.text = "Estado: Error al registrar nuevo usuario | " + _error.GenerateErrorReport();
    }

    #endregion
    
    #region DATOS DEL JUGADOR

    /// <summary>
    /// Método que nos permite inicializar los datos del jugador que inicio sesión.
    /// </summary>
    /// <param name="_PlayFabId">ID único que oermite identificar al jugador.</param>
    private void GetPlayFabPlayerData(string _PlayFabId)
    {
        // Guardamos el ID.
        DatosJugador.Get.PlayFabID = _PlayFabId;
        
        // Guardamos el nombre del usuario.
        var requesProfile = new GetPlayerProfileRequest() { PlayFabId = _PlayFabId };
        PlayFabClientAPI.GetPlayerProfile(requesProfile,
            result =>
            {
                // Se guarda el nombre del jugador y se cargan los datos.
                DatosJugador.Get.Nombre = result.PlayerProfile.DisplayName;
                DatosJugador.Get.ObtenerDatos();
                
                // Invocamos el evento de que fue autentificado.
                evntAutentificado?.Invoke();
                
                // Cargamos la escena del menu.
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            },
            error =>
            {
                Debug.LogError(error.GenerateErrorReport());
            });
    }
    
    #endregion

    #region SET USER FORMS

    /// <summary>
    /// Método que inicializa el formulario para el inicio de sesión.
    /// </summary>
    private void InicializarFormularioInicioSesion()
    {
        _estaIniciandoSesion = true;
        
        textoDeEstado.text               = "Estado: esperando acción del usuario...";
        textoTitulo.text                 = "INICIO DE SESIÓN";
        textoBotonConectar.text          = "Iniciar sesión";
        textoBotonCambiarFormulario.text = "Registrar";
        
        UsernameInputField.SetActive(false);
    }

    /// <summary>
    /// Método que inicializa el formulario para el registro de usuario.
    /// </summary>
    private void InicializarFormularioRegistroUsuario()
    {
        _estaIniciandoSesion = false;
        
        textoDeEstado.text               = "Estado: esperando acción del usuario...";
        textoTitulo.text                 = "REGISTRO";
        textoBotonConectar.text          = "Registrar";
        textoBotonCambiarFormulario.text = "Iniciar sesión";

        UsernameInputField.SetActive(true);
    } 

    #endregion

    #region LÓGICA DEL UI

    /// <summary>
    /// Método que permite cmabiar de formulario.
    /// </summary>
    public void CambiarDeFormulario()
    {
        if (_estaIniciandoSesion) InicializarFormularioRegistroUsuario();
        else InicializarFormularioInicioSesion();
    }
    
    /// <summary>
    /// Método que permite iniciar sesión o registrar al usuario dependiendo del formulario
    /// en el que se encuentre.
    /// </summary>
    public void ConectarUsuario()
    {
        // Obtener el nombre de usuario.
        _username = textoNombreUsuario.text;

        // Obtener el correo del usuario.
        _userEmail = textoCorreoUsuario.text;

        // Obtener la contraseña del usuario.
        _userPassword = textoContraUsuario.text;

        // Iniciar sesión o registrar al usuario.
        if (_estaIniciandoSesion) IniciarSesion();
        else RegistrarUsuario();
    }
    
    #endregion
}
