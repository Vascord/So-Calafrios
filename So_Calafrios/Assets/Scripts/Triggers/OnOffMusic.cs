using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMusic : MonoBehaviour
{
    [SerializeField] private AudioSource[] music;
    private int activatedTimes;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        activatedTimes = 0;
    }

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    public void AudioPlay()
    {
        // Activates/Desactivates music depending of the animation/animator.
        if(!music[activatedTimes].isPlaying)
        {
            music[activatedTimes].Play();
        }
        else
        {
            music[activatedTimes].Stop();
        }

        activatedTimes++;
    }
}
