using UnityEngine;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput = default;
    [SerializeField] private AudioSource deathMusic = default;
    [SerializeField] private AudioSource[] allAudioSources;

    void Awake() 
    {
        allAudioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    private void DeathScene()
    {
        playerInput.enabled = false;

        foreach(AudioSource audioS in allAudioSources) 
        {
            audioS.Stop();
        }

        deathMusic.Play();
    }
}
