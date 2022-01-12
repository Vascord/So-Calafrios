using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveLoadOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private static string SAVE_FOLDER;

    private void Awake()
    {
        SAVE_FOLDER = Application.dataPath + "/Saves/";
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadOptions();
        }

        if(!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public void SaveOptions()
    {
        float audio;
        audioMixer.GetFloat("volume", out audio);
        Resolution screenResolution = Screen.currentResolution;
        int quality = QualitySettings.GetQualityLevel();
        bool fullscreen = Screen.fullScreen;

        OptionsSaveObject optionsSaveObject = new OptionsSaveObject {
            audio = audio,
            screenResolution = screenResolution,
            quality = quality,
            fullscreen = fullscreen
        };
        string json = JsonUtility.ToJson(optionsSaveObject);

        File.WriteAllText(SAVE_FOLDER + "options_save.txt", 
            json);
    }

    public void LoadOptions()
    {
        if(File.Exists(SAVE_FOLDER + "options_save.txt"))
        {
            string saveString = File.ReadAllText(
                SAVE_FOLDER + "options_save.txt");

            OptionsSaveObject optionsSaveOptions = 
                JsonUtility.FromJson<OptionsSaveObject>(saveString);
            
            audioMixer.SetFloat("volume", optionsSaveOptions.audio);
            Screen.SetResolution(optionsSaveOptions.screenResolution.width,
                optionsSaveOptions.screenResolution.height,
                optionsSaveOptions.fullscreen);
            QualitySettings.SetQualityLevel(optionsSaveOptions.quality);
        }
    }
}

public class OptionsSaveObject {
    public float audio;
    public Resolution screenResolution;
    public int quality;
    public bool fullscreen;
}
