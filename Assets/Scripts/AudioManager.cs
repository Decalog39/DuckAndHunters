using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm;
	public AudioSource buttonsound;
    public static AudioManager instance;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }
	 void OnDisable(){
        bgm.Stop();
    }
    void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
     public void click()
    {
        buttonsound.Play();
    }
	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}

    
}
