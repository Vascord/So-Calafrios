using UnityEngine;
using System.Linq;

public class CheckDeaths : MonoBehaviour
{
    [SerializeField] private Chapter0Enemy[] enemies;
    [SerializeField] private AudioSource[] musicsStart;
    [SerializeField] private AudioSource[] musicsStop;

    // Update is called once per frame
    void Update()
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
