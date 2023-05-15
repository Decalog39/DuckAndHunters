using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class InitAudioManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource buttonsound;
    public AudioSource duck;
    public AudioSource hunter;
    
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }

    void OnDisable(){
        bgm.Stop();
    }
    public void click()
    {
        buttonsound.Play();
    }
     public void duckfraction()
    {
        duck.Play();
    }
    public void hunterfraction()
    {
        hunter.Play();
    }
   
    
}
