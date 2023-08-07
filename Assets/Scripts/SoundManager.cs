using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip mainBackgroundMusic;
    public AudioClip bossMusic;
    public AudioClip gameOverMusic;
    void Start()
    {
        
    }
    public void ChangeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}

