using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInventar : MonoBehaviour
{
    private AudioSource aSInventar;
    [SerializeField] AudioClip upCanUI;
    [SerializeField] AudioClip downCanUI;
    [SerializeField] AudioClip upKeyUI;
    [SerializeField] AudioClip downKeyUI;
    [SerializeField] AudioClip upFonarikUI;
    [SerializeField] AudioClip downFonarikUI;
    [SerializeField] AudioClip upBMetalUI;
    [SerializeField] AudioClip downBMetalUI;
    [SerializeField] AudioClip upLMettalUI;
    [SerializeField] AudioClip downLMettalUI;
    public bool isLMettalUiUp = false;
    public bool isLMettalUiDown = false;
    public bool isFonarikUiUp = false;
    public bool isFonarikUiDown = false;
    public bool isKeyUiUp = false;
    public bool isKeyUiDown = false;
    public bool isCanUiUp = false;
    public bool isCanUiDown = false;
    public bool isBMetalUiUp = false;
    public bool isBMetalUiDown = false;
    public bool playSoundInventar;

    void Start()
    {
        aSInventar = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSoundInventar)
        {
            aSInventar.volume = 0.5f;
            aSInventar.Play();
            playSoundInventar = false;
        }
        //ЖелезнаяБанка 
        if (isCanUiUp)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = upCanUI;
            aSInventar.Play();
            isCanUiUp = false;
        }
        if (isCanUiDown)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = downCanUI;
            aSInventar.Play();
            isCanUiDown = false;
        }
        //Ключи 
        if (isKeyUiUp)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = upKeyUI;
            aSInventar.Play();
            isKeyUiUp = false;
        }
        if (isKeyUiDown)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = downKeyUI;
            aSInventar.Play();
            isKeyUiDown = false;
        }
        //Фонарик 
        if (isFonarikUiUp)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = upFonarikUI;
            aSInventar.Play();
            isFonarikUiUp = false;
        }
        if (isFonarikUiDown)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = downFonarikUI;
            aSInventar.Play();
            isFonarikUiDown = false;
        }
        //БольшоеМеталПредмет 
        if (isBMetalUiUp)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = upBMetalUI;
            aSInventar.Play();
            isBMetalUiUp = false;
        } 
        if (isBMetalUiDown)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = downBMetalUI;
            aSInventar.Play();
            isBMetalUiDown = false;
        } 
        //МалыйМеталПредмет 
        if (isLMettalUiUp)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = upLMettalUI;
            aSInventar.Play();
            isLMettalUiUp = false;
        } 
        if (isLMettalUiDown)
        {
            aSInventar.volume = 0.2f;
            aSInventar.clip = downLMettalUI;
            aSInventar.Play();
            isLMettalUiDown = false;
        } 
    }
}
