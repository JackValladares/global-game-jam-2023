using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingOption : MonoBehaviour
{
    public AudioMixer AudioControl;
    public Slider MasterSlider;
    public Slider SoundEffectSlider;
    public Slider BackgroundSlider;

    public void SetSlider()
    {
        AudioManager audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>(); ;
        MasterSlider.value = audioManager.masterVolume;
        SoundEffectSlider.value = audioManager.soundEffectVolume;
        BackgroundSlider.value = audioManager.backgroundSliderVolume;
    }

    public void SetMasterVolume(float volume)
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().masterVolume = volume;
        AudioControl.SetFloat("Master", volume);
        if (MasterSlider.value == -30)
        {
            AudioControl.SetFloat("Master", -80);
        }
    }

    public void SetSoundEffectsVolume(float volume)
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().soundEffectVolume = volume;

        AudioControl.SetFloat("Sound Effect", volume);
        if (SoundEffectSlider.value == -30)
        {
            AudioControl.SetFloat("Sound Effect", -80);
        }
    }
    public void SetBackgroundVolume(float volume)
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().backgroundSliderVolume = volume;

        AudioControl.SetFloat("Background", volume);
        if (BackgroundSlider.value == -30)
        {
            AudioControl.SetFloat("Background", -80);
        }
    }
}