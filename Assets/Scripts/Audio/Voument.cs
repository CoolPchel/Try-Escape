using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Voument : MonoBehaviour
{
    public string volumeParameter = "MasterVolume"; //?
    public AudioMixer mixer;

    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, volumeParameter == "Clik" ? 0f : -80f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }
}
