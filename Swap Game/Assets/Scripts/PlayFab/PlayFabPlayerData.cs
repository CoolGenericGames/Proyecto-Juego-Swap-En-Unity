using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabPlayerData : MonoBehaviour
{
    #region SINGLETON

    /// <summary>
    /// Single instance containing the user's important PlayFab data.
    /// </summary>
    private static PlayFabPlayerData _instance;

    #endregion

    #region PROPERTIES

    /// <summary>
    /// Property that allows us to access the data of the PlayFab player.
    /// </summary>
    public static PlayFabPlayerData Get { get => _instance; }

    /// <summary>
    /// Player name to be displayed in the game.
    /// </summary>
    public string DisplayName { get; set; }
    
    /// <summary>
    /// Unique ID of the player
    /// </summary>
    public string PlayFabID { get; set; }

    #endregion
    
    #region UNITY METHODS

    private void Awake()
    {
        // Init singleton.
        _instance = this;
        
        // Prevent the object from being destroyed.
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
}
