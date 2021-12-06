using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMusic : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    // Start is called before the first frame update
    void AudioPlay()
    {
        music.Play();
    }
}
