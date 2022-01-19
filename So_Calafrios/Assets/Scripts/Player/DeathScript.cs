using UnityEngine;

/// <summary>
/// Class which manage the death of the player.
/// </summary>
public class DeathScript : MonoBehaviour
{
    [SerializeField] private AudioSource deathMusic = default;
    private AudioSource[] allAudioSources;

    /// <summary>
    /// Private method called when the GameObject is initialized.
    /// </summary>
    private void Awake() 
    {
        allAudioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) 
            as AudioSource[];
    }

    /// <summary>
    /// Private method called when the player dies.
    /// </summary>
    private void DeathScene()
    {
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
