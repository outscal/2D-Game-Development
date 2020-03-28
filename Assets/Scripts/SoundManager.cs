using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource playerSource;
    public AudioSource collectibleSource;
    public AudioSource gameSfxSource;
    public AudioSource gameEffectSource;
    public AudioSource uiSource;

    public PlayerClipping[] playerSounds;
    public CollectibleClipping[] collectibleSound;
    public GameSfxClipping[] gameSound;
    public GameEffectsClipping[] gameEffectSound;
    public UISfxClipping[] uiSound;
   


    [Serializable]
    public class PlayerClipping
    {
        public Sfx.PlayerSfx playerSfx;
        public AudioClip clip;
    }
    [Serializable]
    public class CollectibleClipping
    {
        public Sfx.CollectibleSfx collectibleSfx;
        public AudioClip clip;
    }
    
    [Serializable]
    public class GameSfxClipping
    {
        public Sfx.GameSfx gameSfx;
        public AudioClip clip;
    }
    
    [Serializable]
    public class GameEffectsClipping
    {
        public Sfx.GameSfx gameEffect;
        public AudioClip clip;
    }

    [Serializable]
    public class UISfxClipping
    {
        public Sfx.UISfx uiSfx;
        public AudioClip clip;
    }
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

    private void Start()
    {
    }

    public void playPlayerSound(Sfx.PlayerSfx playerSfx, bool isLoop)
    {
        playerSource.clip = playerSounds[(int)playerSfx].clip;
        playerSource.Play(0);
        playerSource.loop = isLoop;
    }

    public void playCollectibleSound(Sfx.CollectibleSfx collectibleSfx, bool isLoop)
    {
        collectibleSource.clip = collectibleSound[(int)collectibleSfx].clip;
        collectibleSource.Play(0);
        collectibleSource.loop = isLoop;
    }


    public void playGameSound(Sfx.GameSfx gameSfx, bool isLoop)
    {
        gameSfxSource.clip = gameSound[(int)gameSfx].clip;
        gameSfxSource.Play(0);
        gameSfxSource.volume = 0.1f;
        gameSfxSource.loop = isLoop;
    }
    public void playGameEffect(Sfx.GameEffects gameEffect, bool isLoop)
    {
        gameEffectSource.clip = gameEffectSound[(int)gameEffect].clip;
        gameEffectSource.Play(0);
        gameEffectSource.loop = isLoop;
    }


   
    public void playUiEffectSound(Sfx.UISfx uiSfx, bool isLoop)
    {

        uiSource.clip = uiSound[(int)uiSfx].clip;
        uiSource.Play(0);
        uiSource.loop = isLoop;
    }


}
