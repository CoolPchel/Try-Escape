using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Этот скрипт работает с AudioMixer

public class VolumeControl : MonoBehaviour
{
    public string volumeParameter = "MasterVolume"; //?
    public AudioMixer mixer;
    public Slider slider;

    private float _volumeValue;//В нем будет сохранение
    private const float _multiplier = 20f; //Констата 

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, _volumeValue);
    }

    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier);//Загружает
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);//Сохраняет
    }
}
