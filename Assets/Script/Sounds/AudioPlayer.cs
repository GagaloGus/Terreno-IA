using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public Sounds[] sfxSounds;
    public AudioSource sfxSource;

    public void PlaySFX(string name, float volume = 1)
    {
        Sounds sfx = Array.Find(sfxSounds, x => x.name == name);
        if(sfx != null)
        {
            sfxSource.volume = volume;
            sfxSource.PlayOneShot(sfx.clip);
        }
        else { print("Sfx no encontrado"); }

    }
}
