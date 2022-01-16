using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadOptionsPrefs : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = default;
    [SerializeField] private MouseLook mouse = default;
    [SerializeField] private Light sceneLight = default;


    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if(PlayerPrefs.GetInt("quality") != 0)
            {
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
            }

            if(PlayerPrefs.GetFloat("volume") != 0)
            {
                audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
            }

            if(PlayerPrefs.GetString("screen") != null)
            {
                Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.
                    GetString("screen"));
            }
        }
        else
        {
            if(PlayerPrefs.GetFloat("mouse sensitivity") != 0)
            {
                mouse.mouseSensitivity = PlayerPrefs.
                    GetFloat("mouse sensitivity");
            }
            if(PlayerPrefs.GetFloat("brightness") != 0)
            {
                sceneLight.intensity = PlayerPrefs.GetFloat("brightness");
            }
        }
    }
}
