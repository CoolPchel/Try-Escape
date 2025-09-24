using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSicret : MonoBehaviour, IInteractable
{
    public GameObject vhod;
    public GameObject twoChapter;
    public AudioSource audi;
    [SerializeField] AudioClip sound;

    public string GetDescription()
    {
        return "?";
    }

    public void Interact() 
    {
        audi.clip = sound;
        audi.Play();
        twoChapter.SetActive(true);
        Destroy(vhod);
    }

    
}
