using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMusic : MonoBehaviour
{
    [SerializeField] private AudioSource[] music;
    private int activatedTimes;

    void Start()
    {
        activatedTimes = 0;
    }

    // Start is called before the first frame update
    public void AudioPlay()
    {
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
