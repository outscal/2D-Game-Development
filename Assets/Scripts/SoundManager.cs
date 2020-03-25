using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource source;
    public AudioSource effectSource;
    public AudioSource musicSource;
    public AudioSource playerSource;
    public AudioSource uiSource;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void play(AudioClip clip)
    {
        source.clip = clip;
        source.Play(0);
    } 

    public void playEffect(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play(0);
    } 
    public void playMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play(0);
    }
    public void playPlayerSound(AudioClip clip)
    {
        playerSource.clip = clip;
        playerSource.Play(0);
    }
    public void playUiEffect(AudioClip clip)
    {
        uiSource.clip = clip;
        uiSource.Play(0);
    }


}
