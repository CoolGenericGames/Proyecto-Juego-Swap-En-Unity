using System;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayFabFormularioLogin : MonoBehaviour
{
    #region ACTIONS & EVENTS

    /// <summary>
    /// Action that is invoked when all user data is obtained.
    /// </summary>
    public static Action OnAuthenticated;
    
    #endregion

    #region PRIVATE FIELDS

    /// <summary>
    /// Represents the name of the user profile. It is the name that the user will use in the game.
    /// </summary>
    private string _username;
    
    /// <summary>
    /// Represents the user's email address. Required to login.
    /// </summary>
    private string _userEmail;
    
    /// <summary>
    /// Represents the password of the account that the user will use to log in.
    /// </summary>
    private string _userPassword;

    /// <summary>
    /// It lets you know if the user is in the login form or not.
    /// </summary>
    private bool _isOnLoginForm;

    #endregion
    
    #region PUBLIC UI COMPONENTS

    [Header("TextMeshPro Texts")] // --------------------------------------------------
    
    /// <summary>
    /// Reference to the title of the connect form.
    /// </summary>
    public TextMeshProUGUI TitleText;
    
    /// <summary>
    /// Reference the button text of the connect form.
    /// </summary>
    public TextMeshProUGUI ConnectButtonText;
    
    /// <summary>
    /// Reference to the button text the connect form that allows you to switch between
    /// the user login and the new user registration forms.
    /// </summary>
    public TextMeshProUGUI ChangeFormButtonText;
    
    /// <summary>
    /// Reference to the status text of the connect form.
    /// </summary>
    public TextMeshProUGUI StatusText;

    [Header("Input Fields Texts")] // ------------------------------------------------

    /// <summary>
    /// Represents the username text field
    /// </summary>
    public Text UsernameText;

    /// <summary>
    /// Represents the user email text field
    /// </summary>
    public TextMeshProUGUI UserEmailText;

    /// <summary>
    /// Represents the user password text field
    /// </summary>
    public TextMeshProUGUI UserPassword;


    [Header("UI Objects")] // --------------------------------------------------------
    
    /// <summary>
    /// Reference to the InputField game object that captures the username.
    /// </summary>
    public GameObject UsernameInputField;


    #endregion PUBLIC UI COMPONENTS
    
    #region UNITY METHODS

    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
            PlayFabSettings.TitleId = "9CC1F";
        
        SetLoginForm();
    }

    #endregion

    #region LOGIN USER METHODS

    /// <summary>
    /// Method that allows the user to log in.
    /// </summary>
    private void OnLoginUser()
    {
        var request = new LoginWithEmailAddressRequest() { Email = _userEmail, Password = _userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    /// <summary>
    /// Method that is invoked when the user succeeds in logging in successfully.
    /// </summary>
    /// <param name="_result"></param>
    private void OnLoginSuccess(LoginResult _result)
    {
        Debug.Log("Login success.");
        
        // Init player data.
        GetPlayFabPlayerData(_result.PlayFabId);

        // Desactive this object.
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Method that is invoked when the user fails to log in successfully.
    /// </summary>
    /// <param name="_error"></param>
    private void OnLoginFailure(PlayFabError _error)
    {
        StatusText.text = "Status: Login failure " + _error.GenerateErrorReport();
    }

    #endregion

    #region REGISTER USER METHODS

    /// <summary>
    /// Method that is invoked when you want to register a new user.
    /// </summary>
    private void OnRegisterUser()
    {
        if (!string.IsNullOrEmpty(_userEmail))
            _userEmail = _userEmail.ToLower();

        if (!string.IsNullOrEmpty(_username))
            _username = _username.ToUpper();


        Debug.LogWarning("Email: " + _userEmail);
        Debug.LogWarning("Password: " + _userPassword);
        Debug.LogWarning("Username: " + _username);


        var request = new RegisterPlayFabUserRequest()
        {
            Email = _userEmail,
            Password = _userPassword,
            Username = _username,
            DisplayName = _username
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterUserSuccess, OnRegisterUserFailure);
    }
    
    /// <summary>
    /// Method that is invoked when the user registers successfully.
    /// </summary>
    /// <param name="_result"></param>
    private void OnRegisterUserSuccess(RegisterPlayFabUserResult _result)
    {
        Debug.Log("User register success.");
        
        StatusText.text = "Status: register new user success";

        OnLoginUser();
    }

    /// <summary>
    /// Method that is invoked when the user did not register successfully.
    /// </summary>
    /// <param name="_error"></param>
    private void OnRegisterUserFailure(PlayFabError _error)
    {
        StatusText.text = "Status: register new user failure " + _error.GenerateErrorReport();
        Debug.LogError("Here's some debug information:");
        Debug.LogError(_error.GenerateErrorReport());
    }

    #endregion
    
    #region GET PLAYER DATA

    /// <summary>
    /// Method that allows obtaining all user data.
    /// </summary>
    /// <param name="_PlayFabId"> Unique ID of the player </param>
    private void GetPlayFabPlayerData(string _PlayFabId)
    {
        // Set player PlayFabID.
        DatosJugador.Get.PlayFabID = _PlayFabId;
        
        // Set player display name.
        var requesProfile = new GetPlayerProfileRequest() { PlayFabId = _PlayFabId };
        PlayFabClientAPI.GetPlayerProfile(requesProfile,
            result =>
            {
                DatosJugador.Get.Nombre = result.PlayerProfile.DisplayName;
                
                // Invoke the action that the user has been authenticated
                OnAuthenticated?.Invoke();
                
                // Load game menu scene.
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
    /// Method that allows initializing the connect form to log in.
    /// </summary>
    private void SetLoginForm()
    {
        _isOnLoginForm = true;
        
        StatusText.text           = "STATUS: WAITING";
        TitleText.text            = "LOGIN FORM";
        ConnectButtonText.text    = "Login";
        ChangeFormButtonText.text = "Register user";
        
        UsernameInputField.SetActive(false);
    }

    /// <summary>
    /// Method that allows initializing the connect form to register a new user.
    /// </summary>
    private void SetRegisterForm()
    {
        _isOnLoginForm = false;
        
        StatusText.text           = "STATUS: WAITING";
        TitleText.text            = "REGISTER FORM";
        ConnectButtonText.text    = "Register";
        ChangeFormButtonText.text = "Login";

        UsernameInputField.SetActive(true);
    } 

    #endregion

    #region UI LOGIC

    /// <summary>
    /// Allows the user to change forms.
    /// </summary>
    public void OnChangeForm()
    {
        if (_isOnLoginForm) SetRegisterForm();
        else SetLoginForm();
    }
    
    /// <summary>
    /// Method that allows you to log in or register a new user depending on the form.
    /// </summary>
    public void OnConnectUser()
    {
        // Get the username.
        _username = UsernameText.text;

        // Get the user e-mail.
        _userEmail = UserEmailText.text;

        // Get the user password.
        _userPassword = UserPassword.text;

        // Login or register user.
        if (_isOnLoginForm) OnLoginUser();
        else OnRegisterUser();
    }
    
    #endregion
}
