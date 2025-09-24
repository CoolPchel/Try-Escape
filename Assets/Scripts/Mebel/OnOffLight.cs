using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnOffLight : MonoBehaviour, IInteractable
{
    public bool off;
    public Animator amLight;
    [SerializeField] AudioClip clickOnLight;
    public AudioSource audi;
    private bool click;

    void Start()
    {
        audi = GetComponent<AudioSource>();
        if(off)
        {
            amLight.GetComponent<Animator>().SetBool("Off", true);
        }
        else
        {
            amLight.GetComponent<Animator>().SetBool("Off", false);
        }
    }
    private void ClipStart()
    {
        audi.clip = clickOnLight;
        audi.Play();
    }

    void Update()
    {
        if (click)
        {
            ClipStart();
            click = false;
        }
    }

    public string GetDescription()
    {
        if (off) return "<color=green> Включить </color>";
        return "<color=red> Выключить </color>";
    }
    public void Interact() 
    {
        off = !off;
        click = true;
        if(off)
        {
            amLight.GetComponent<Animator>().SetBool("Off", true);
        }
        else
        {
            amLight.GetComponent<Animator>().SetBool("Off", false);
        }     
    }
}
