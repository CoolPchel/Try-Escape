using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Item : MonoBehaviour, IInteractable
{
    public Transform tPoit;
    [SerializeField] AudioClip down;
    [SerializeField] AudioClip downOnTeble;
    private AudioSource itSource;
    public ItemScriptableObject item; // чтобы программа поняла какая группа у придмета
    public int amount; //сколько дадут этот придмет при поднятии

    void Start()
    {
        tPoit = GameObject.FindGameObjectWithTag("Tp").transform;
        itSource = GetComponent<AudioSource>();
        itSource.playOnAwake = false;
        itSource.volume = 0.7f;
        itSource.spatialBlend = 1f;
        itSource.maxDistance = 10f;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "FlorWood")
        {   
            itSource.clip = down;
            itSource.Play();
        }
        if (other.transform.tag == "TableS")
        {   
            itSource.clip = downOnTeble;
            itSource.Play();
        }

        if (other.transform.tag == "ZonaTp")
        {
            gameObject.transform.position = new Vector3(tPoit.position.x,tPoit.position.y,tPoit.position.z);
        }
    }

    public string GetDescription()
    {
        return "Подобрать";
    }
    public void Interact() 
    {

    }
}