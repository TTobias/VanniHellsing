using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source =gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

        }
    }

   public void PlaySound(string name,GameObject g)
   {
        Sound s= Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log(g + " Didnt found Sound");
            return;
        }
        s.source.Play();
   }

    public void StopSound(string name, GameObject g)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(g + " Didnt found Sound");
            return;
        }
        s.source.Stop();
    }

    public void PlaySoundReaped(string name , GameObject g)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(g + " Didnt found Sound");
            return;
        }
        if (s.canReapItself)
        {
            StartCoroutine(RestartReapedAudio(s));
            s.source.Play();
        }
    }

    IEnumerator RestartReapedAudio(Sound s){
        s.canReapItself = false;
        yield return new WaitForSeconds(s.timeBetweenRapeats);
        s.canReapItself = true;
    }
}
