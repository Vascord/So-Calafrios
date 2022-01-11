using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = default;
    [SerializeField] private Slider slider = default;
    [SerializeField] private Toggle toggle = default;
    [SerializeField] private TMP_Dropdown resolutionDropdown = default;
    private Resolution[] resolutions;
    private int currentresolutionIndex;


    private void Start()
    {
        // Adjust the slider to the actual volume of the game.
        float audio;
        audioMixer.GetFloat("volume", out audio);
        slider.value = audio;
        toggle.isOn = Screen.fullScreen;

        // Adds all the resolutions of the existing ones to the dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        currentresolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height
                + " Hz " + +resolutions[i].refreshRate;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,
            resolution.height,
            Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = toggle.isOn;
    }
}

