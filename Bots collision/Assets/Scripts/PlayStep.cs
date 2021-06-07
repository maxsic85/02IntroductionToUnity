using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayStep : MonoBehaviour
{
    public AudioClip _step;
    AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
         _audio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audio.PlayOneShot(_step);
    }
}
