using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MUSICMANAGER1: MonoBehaviour

   {
    public AudioMixer mixer; // اربطه بالـ MainMixer من Inspector

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}
