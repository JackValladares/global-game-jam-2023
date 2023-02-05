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

public enum E_BackGroundMusic { 
    Titlescreen,
    Victory,
    Game_Over,
    Level_1,
    Level_2,
    Level_3,
    Level_Extra
}
public enum E_SoundEffect { 
    Click,
    Voice,
    Walk,
    Pip,
    Elder_leaf
}

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
                Instance.ChangeBackground(E_BackGroundMusic.Titlescreen);
                break;
            case "Level One":
                Instance.ChangeBackground(E_BackGroundMusic.Level_1);
                break;
            case "Level Two":
                Instance.ChangeBackground(E_BackGroundMusic.Level_2);
                break;
            case "Level Three":
                Instance.ChangeBackground(E_BackGroundMusic.Level_3);
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

    public void PlaySoundEffect2()
    {
        Debug.Log("Test");
    }







}
