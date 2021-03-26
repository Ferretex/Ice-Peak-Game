using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    static public float setValue = -20;
    public Slider volSlider;

    void Start()
    {
        audioMixer.SetFloat("volume", setValue);
        volSlider.value = setValue;
    }
    public void SetVolume (float volume)
    {
        //Debug.Log(volume);

        audioMixer.SetFloat("volume", volume);
        setValue = volume;
        
    }
}
