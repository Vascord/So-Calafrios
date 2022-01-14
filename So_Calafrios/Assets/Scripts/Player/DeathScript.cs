using UnityEngine;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput = default;
    [SerializeField] private AudioSource deathMusic = default;
    [SerializeField] private AudioSource[] allAudioSources;

    /// <summary>
    /// Private method called when the GameObject is initialized.
    /// </summary>
    void Awake() 
    {
        allAudioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) 
            as AudioSource[];
    }

    /// <summary>
    /// Private method called when the player dies.
    /// </summary>
    private void DeathScene()
    {
        playerInput.enabled = false;

        foreach(AudioSource audioS in allAudioSources) 
        {
            if(audioS)
            {
                audioS.Stop();
            }
        }

        if(!deathMusic)
        {
            deathMusic.enabled = true;
        }
        deathMusic.Play();
    }
}
