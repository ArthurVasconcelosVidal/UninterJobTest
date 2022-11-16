using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound{
    public AudioClip audioClip;
    public SoundList soundName;
    [Range(0,1)] public float volume;
    public float pitch = 1;
    public bool loop;
    public bool playOnAwake = false;

    public AudioSource AudioSource {get; set;}
}
