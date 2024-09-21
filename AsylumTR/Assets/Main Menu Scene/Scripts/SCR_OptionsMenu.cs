using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SCR_OptionsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void SetVolume(float Volume)
    {
        AudioMixer.SetFloat("VolumeParameter", Volume);
    }

    public void SetQuality(int QualityList)
    {
        QualitySettings.SetQualityLevel(QualityList);
    }

    public void SetFullscreen(bool Fullscreen)
    {
        Screen.fullScreen = Fullscreen;
    }
}
