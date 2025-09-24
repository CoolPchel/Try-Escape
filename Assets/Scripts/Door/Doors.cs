using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Doors : MonoBehaviour, IInteractable
{
    public List<GameObject> dor23;
    private bool giveOneTask = false;
    public AllTask task;
    [SerializeField] AudioClip open;
    [SerializeField] AudioClip clouse;
    [SerializeField] AudioClip cantOpen; 
    private AudioSource audioSource;
    private Animator dorAm;
    public bool isOpen;
    private bool playSound;
    public bool loked;
    public bool canUseDoor = true;
    //Для обучения
    public bool ay;

    // Start is called before the first frame update
    void Start()
    {
        dorAm = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = 1f;
        audioSource.spatialBlend = 10f;
        audioSource.maxDistance = 20f;
        if (!canUseDoor)
        {
            Destroy(dor23[0]);
            Destroy(dor23[1]);
        }
    }
    void Update()
    {
        if (playSound)
        {
            audioSource.Play();
            playSound = false;
        }
    }
    public string GetDescription()
    {
        if (!canUseDoor)
        {
            return "<color=red>Закрыто</color>";
        }
        if (loked)
        {
            return "<color=red>Закрыто</color>";
        }
        if (isOpen)
        {
            return "<color=red>Закрыть</color>";
        }
        return "<color=green>Открыть</color>";
    }
    public void Interact() //На кнопку F уже готовый скрипт в PlayerInteraction
    {
        if (canUseDoor)
        {
            if (!loked)
            {
                isOpen = !isOpen;
                if (isOpen)
                {
                    audioSource.clip = open;
                    dorAm.SetBool("isOpen", true);
                    playSound = true;
                }
                else
                {
                    audioSource.clip = clouse;
                    dorAm.SetBool("isOpen", false);
                    playSound = true;   
                }
            }
            else
            {
                audioSource.clip = cantOpen;
                playSound = true;
                //Задание
                if (gameObject.tag == "DoorOrange" && !giveOneTask)
                {
                    task.oredgeDoor = true;
                    ay = true;
                    giveOneTask = true;
                }
                if (gameObject.tag == "DoorRed" && !giveOneTask)
                {
                    task.redDoor = true;
                    giveOneTask = true;
                }
                if (gameObject.tag == "DoorGreen" && !giveOneTask)
                {
                    task.greenDoor = true;
                    giveOneTask = true;
                }
            }
        }
        else
        {
            audioSource.clip = cantOpen;
            playSound = true;
        }
    }
}
