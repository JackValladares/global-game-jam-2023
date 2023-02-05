using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    [Header("Current Audio Playing")]
    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;

    [Header("Sound Effect Reference")]
    public AudioSource Click;
    public AudioSource Voice;
    public AudioSource Walk;
    public AudioSource Pip;
    public AudioSource ElderLeaf;

    [Header("Background Reference")]
    public AudioSource Titlescreen;
    public AudioSource Victory;
    public AudioSource GameOver;
    public AudioSource Level1;
    public AudioSource Level2;
    public AudioSource Level3;
    public AudioSource LevelExtra;

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

        switch (background)
        {
            case E_BackGroundMusic.Titlescreen:
                BackgroundMusic = Titlescreen;
                break;
            case E_BackGroundMusic.Victory:
                BackgroundMusic = Victory;
                break;
            case E_BackGroundMusic.Game_Over:
                BackgroundMusic = GameOver;
                break;
            case E_BackGroundMusic.Level_1:
                BackgroundMusic = Level1;
                break;
            case E_BackGroundMusic.Level_2:
                BackgroundMusic = Level2;
                break;
            case E_BackGroundMusic.Level_3:
                BackgroundMusic = Level3;
                break;
            case E_BackGroundMusic.Level_Extra:
                BackgroundMusic = LevelExtra;
                break;
        }

        BackgroundMusic.Play();
    }

    public void PlaySoundEffect(E_SoundEffect soundEffect)
    {

        switch (soundEffect)
        {
            case E_SoundEffect.Click:
                Click.Play();
                break;
            case E_SoundEffect.Voice:
                Voice.Play();
                break;
            case E_SoundEffect.Walk:
                Walk.Play();
                break;
            case E_SoundEffect.Pip:
                Pip.Play();
                break;
            case E_SoundEffect.Elder_leaf:
                ElderLeaf.Play();
                break;
        }
    }

    public void StopSoundEffect(E_SoundEffect soundEffect)
    {

        switch (soundEffect)
        {
            case E_SoundEffect.Elder_leaf:
                ElderLeaf.Stop();
                break;
            case E_SoundEffect.Pip:
                Pip.Stop();
                break;
        }
    }
}
