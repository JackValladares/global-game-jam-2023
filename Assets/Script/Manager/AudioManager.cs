using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[Serializable]
public class ESoundEffectAudioSourceDictionary : SerializableDictionary<E_SoundEffect, UnityEngine.AudioSource> { }
[Serializable]
public class EBackgroundMusicAudioSourceDictionary : SerializableDictionary<E_BackGroundMusic, UnityEngine.AudioSource> { }

public enum E_BackGroundMusic { Placeholder }
public enum E_SoundEffect { Placeholder }

public class AudioManager : MonoBehaviour
{
    [SerializeField] public static AudioManager Instance;
    
    [Header("Music Reference")]
    public ESoundEffectAudioSourceDictionary SoundEffectDictionary;

    [Header("Sound Effect Reference")]
    public EBackgroundMusicAudioSourceDictionary BackgroundMusicDictionary;

    [Header("Current Audio Playing")]
    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;

    [Header("Volume")]
    public float masterVolume = -15;
    public float soundEffectVolume = -15;
    public float backgroundSliderVolume = -15;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.name)
        {
            case "Main Menu":
                Instance.ChangeBackground(E_BackGroundMusic.Placeholder);
                break;
            case "Main Game":
                Instance.ChangeBackground(E_BackGroundMusic.Placeholder);
                break;
        }
    }

    public void ChangeBackground(E_BackGroundMusic background)
    {

        if (BackgroundMusic.isPlaying)
            BackgroundMusic.Stop();
        BackgroundMusic = BackgroundMusicDictionary[background];

        BackgroundMusic.Play();
    }

    public void PlaySoundEffect(E_SoundEffect soundEffect)
    {
        SoundEffectDictionary[soundEffect].Play();
    }







}
