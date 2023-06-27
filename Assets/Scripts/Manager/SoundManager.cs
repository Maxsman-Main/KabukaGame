using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable.Sound;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, footstepSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        PlayMusic("Level 1");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound is null) return;
        musicSource.clip = sound.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound is null) return;
        sfxSource.PlayOneShot(sound.clip);
    }
    public void PlayFootstep()
    {
        footstepSource.enabled = true;
    }
    
    public void StopFootstep()
    {
        footstepSource.enabled = false;
    }
}