using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = default;
    [SerializeField] private MouseLook mouse = default;
    [SerializeField] private Light sceneLight = default;
    [SerializeField] private Camera cameraObject = default;
    [SerializeField] private Slider volumeSlider = default;
    [SerializeField] private Slider mouseSlider = default;
    [SerializeField] private Slider lightSlider = default;
    [SerializeField] private Slider cameraSlider = default;
    [SerializeField] private Toggle toggle = default;
    [SerializeField] private TMP_Dropdown resolutionDropdown = default;
    [SerializeField] private TMP_Dropdown qualityDropdown = default;
    private Resolution[] resolutions;
    private int currentresolutionIndex;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Adjust the sliders/dropdowns/toggles to the actual volume, quality, 
        // mouse sensitivity, brightness and fullscreen of the game of the game.
        float audio;
        audioMixer.GetFloat("volume", out audio);
        volumeSlider.value = audio;

        qualityDropdown.value = QualitySettings.GetQualityLevel();

        toggle.isOn = Screen.fullScreen;

        if(mouse != null || sceneLight != null || cameraSlider != null)
        {
            mouseSlider.value = mouse.mouseSensitivity;

            lightSlider.value = sceneLight.intensity;

            cameraSlider.value = cameraObject.fieldOfView;
        }

        toggle.isOn = Screen.fullScreen;

        // Adds all the resolutions of the existing ones to the dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        currentresolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height +
            "&" + resolutions[i].refreshRate;
            options.Add(option);

            currentresolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /// <summary>
    /// Private method called when the player changes the resolution of the
    /// game.
    /// </summary>
    /// <param name="resolutionIndex">Input of the resolution's associated 
    /// number in the list.</param>
    private void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, 
            Screen.fullScreen);
    }

    /// <summary>
    /// Private method called when the player changes the volume of the
    /// game and saves it in player prefs.
    /// </summary>
    /// <param name="volume">Input of the desired volume.</param>
    private void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    /// <summary>
    /// Private method called when the player changes the mouse sensitivity of 
    /// the game and saves it in player prefs.
    /// </summary>
    /// <param name="value">Input of the desired mouse sensitivity.</param>
    private void SetMouseSpeed(float value)
    {
        mouse.mouseSensitivity = value;
        PlayerPrefs.SetFloat("mouse sensitivity", value);
    }

    /// <summary>
    /// Private method called when the player changes the brightness of the
    /// game and saves it in player prefs.
    /// </summary>
    /// <param name="value">Input of the desired brightness.</param>
    private void SetLight(float value)
    {
        sceneLight.intensity = value;
        PlayerPrefs.SetFloat("brightness", value);
    }

    /// <summary>
    /// Private method called when the player changes the field of view of the
    /// game and saves it in player prefs.
    /// </summary>
    /// <param name="value">Input of the desired field of view.</param>
    private void SetFOV(float value)
    {
        cameraObject.fieldOfView = value;
        PlayerPrefs.SetFloat("FOV", value);
    }

    /// <summary>
    /// Private method called when the player changes the quality of the
    /// game and saves it in player prefs.
    /// </summary>
    /// <param name="qualityIndex">Input of the quality's associated 
    /// number in the list.</param>
    private void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
    }

    /// <summary>
    /// Private method called when the player wants fullscreen or not 
    /// and saves it in player prefs.
    /// </summary>
    private void SetFullscreen()
    {
        Screen.fullScreen = toggle.isOn;
        PlayerPrefs.SetString("screen", toggle.isOn.ToString());
    }
}
