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
    [SerializeField] private Slider volumeSlider = default;
    [SerializeField] private Slider mouseSlider = default;
    [SerializeField] private Slider lightSlider = default;
    [SerializeField] private Toggle toggle = default;
    [SerializeField] private TMP_Dropdown resolutionDropdown = default;
    [SerializeField] private TMP_Dropdown qualityDropdown = default;
    private Resolution[] resolutions;
    private int currentresolutionIndex;


    private void Start()
    {
        // Adjust the slider to the actual volume of the game.
        float audio;
        audioMixer.GetFloat("volume", out audio);
        volumeSlider.value = audio;

        qualityDropdown.value = QualitySettings.GetQualityLevel();

        toggle.isOn = Screen.fullScreen;

        if(mouse != null || sceneLight != null)
        {
            mouseSlider.value = mouse.mouseSensitivity;

            lightSlider.value = sceneLight.intensity;
        }

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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, 
            Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetMouseSpeed(float value)
    {
        mouse.mouseSensitivity = value;
        PlayerPrefs.SetFloat("mouse sensitivity", value);
    }

    public void SetLight(float value)
    {
        sceneLight.intensity = value;
        PlayerPrefs.SetFloat("brightness", value);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = toggle.isOn;
        PlayerPrefs.SetString("screen", toggle.isOn.ToString());
    }
}

