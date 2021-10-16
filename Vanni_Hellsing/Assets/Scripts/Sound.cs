using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
    public bool loop;
    public bool playOnAwake;
    [Range(0f, 1f)]
    public float volume = 0.5f;
    [Range(.1f, 3f)]
    public float pitch = 1f;
    [HideInInspector]public AudioSource source;

    public bool canReapItself = true;
    public float timeBetweenRapeats= 0.5f;
}
