using UnityEngine;

/// <summary>
/// Class which changes the music played when all enemies are destroyed.
/// </summary>
public class CheckDeaths : MonoBehaviour
{
    [SerializeField] private Chapter0Enemy[] enemies;
    [SerializeField] private AudioSource[] musicsStart;
    [SerializeField] private AudioSource[] musicsStop;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(CheckAlive())
        {
            foreach(AudioSource music in musicsStart)
            {
                music.Play();
            }

            foreach(AudioSource music in musicsStop)
            {
                music.Stop();
            }

            Destroy(this);
        }
    }

    /// <summary>
    /// Private method that checks if every enemy is alive or not.
    /// </summary>
    private bool CheckAlive()
    {
        bool check = true;
        
        foreach(Chapter0Enemy enemy in enemies)
        {
            if(enemy != null)
            {
                check = false;
            }
        }

        return check;
    }
}
