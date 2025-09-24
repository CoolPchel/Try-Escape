using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sechik : MonoBehaviour, IInteractable
{
    public AudioSource audiSechik;
    [SerializeField] AudioClip open;
    [SerializeField] AudioClip acrivat;
    public InfoTask taskCompliti;
    public Sechik switchi;
    private bool giveOneTask = false;
    public AllTask task;
    public Animator amSetchik;
    public GameObject Knob;
    public bool isKnob;
    public bool noKnob;
    public bool haveKnob = false;
    public bool activ = false;
    public bool sechikDontHaveKnob;
    private bool complite = false;
    public bool isTaskSetchik;


    // Start is called before the first frame update
    void Start()
    {
        if (noKnob)
        {
            Knob.SetActive(false);
        }
        if (isKnob)
        {
            complite = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (haveKnob)
        {
            Knob.SetActive(true);
            noKnob = false;
        }
        if (sechikDontHaveKnob)
        {
            if (switchi.noKnob && complite && !giveOneTask)
            {
                task.knob = true;
                giveOneTask = true;
            }
        }
        
    }
    private void AudiPlay()
    {
        audiSechik.Play();
    }

    public string GetDescription()
    {
        if (noKnob) return "Не хватает рубильника";
        if (!complite) return "Открыть";
        if (!activ) return "Включить";
        return "";
    }
    public void Interact() 
    {
        if(!isKnob && !complite)
        {
            audiSechik.clip = open;
            amSetchik.SetTrigger("isOpen");
            complite = true;
            activ = true;
            AudiPlay();
        }
        if(isKnob && !activ)
        {
            audiSechik.clip = acrivat;
            amSetchik.SetTrigger("StartWork");
            if (isTaskSetchik)
            {
                taskCompliti.proverca = true;
                taskCompliti.nameComplitTask = "Рубильник";
                isTaskSetchik = false;
            }
            activ = true;
            AudiPlay();
        }
    }
}
