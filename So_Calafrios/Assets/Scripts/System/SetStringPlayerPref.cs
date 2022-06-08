using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStringPlayerPref : MonoBehaviour
{
    public void SetPlayerPref(string stringName)
    {
        PlayerPrefs.SetString(stringName, "true");
    }
}
