using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which sets a name to true in the player Prefs.
/// </summary>
public class SetStringPlayerPref : MonoBehaviour
{
    /// <summary>
    /// Public void which keeps the name of the stringName in the Player Prefs.
    /// </summary>
    /// <param name="stringName">Name of the value to keep in Player 
    /// Prefs</param>
    public void SetPlayerPref(string stringName)
    {
        PlayerPrefs.SetString(stringName, "true");
    }
}
