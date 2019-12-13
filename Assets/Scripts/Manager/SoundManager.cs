using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    public AudioClip background;
    public AudioClip swordEffect;
    public AudioClip blockEffect;

    // Singleton instance.
    public static SoundManager Instance = null;
    static bool AudioBegin = false;

    // Initialize the singleton instance.
   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            MusicSource.Play();
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Play a single clip through the sound effects source.
    public void PlaySlash()
    {
        EffectsSource.clip = swordEffect;
        EffectsSource.Play();
    }

    public void PlayBlock()
    {
        EffectsSource.clip = blockEffect;
        EffectsSource.Play();
    }
}

