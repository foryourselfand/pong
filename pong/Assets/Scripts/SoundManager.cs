using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Holds the single instance of the SoundManager that can be accessed from any other script
    public static SoundManager Instance = null;

    // Will hold the sound effects
    public AudioClip goalBloop, lossBuzz, hitPaddleBloop, winSound, wallBloop;

    // Refers to the AudioSource added to SoundManager to play sound effects
    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start()
    {
        // This is a singleton that makes sure you only ever have one SoundManager
        if (Instance == null)
            Instance = this;
        // If someone tries to create another destroy it
        else
        {
            Destroy(gameObject);
        }

        soundEffectAudio = GetComponent<AudioSource>();
    }
    
    // Any script can call this to play a sound effect
    public void PlayOnShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}