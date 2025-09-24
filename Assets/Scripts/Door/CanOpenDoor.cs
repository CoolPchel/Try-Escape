using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOpenDoor : MonoBehaviour
{
    private AudioSource sourse;
    [SerializeField] AudioClip crashDoor; 
    [SerializeField] AudioClip openBot; 
    public TriggerABots tABot;
    public List<GameObject> dor2;
    private bool one;
    private Animator amDoor;
    private Doors door;
    public GameObject boti;
    private UnityEngine.AI.NavMeshObstacle ob;
    public bool isCanOpen = true;
    public bool imHere;
    private bool isAgree;
    
    void Awake()
    {
        boti = GameObject.FindGameObjectWithTag("Scare");
    }

    void Start()
    {
        sourse = GetComponent<AudioSource>();
        tABot = FindObjectOfType<TriggerABots>();
        amDoor = GetComponent<Animator>();
        door = GetComponent<Doors>();
        ob = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (!door.canUseDoor)
        {
            isCanOpen = false;
        }
        if (!isCanOpen)
        {
            ob.enabled = true;
        }
    }


    void Update()
    {

        if (tABot.botActive)
        {
            if (boti.GetComponent<Bot>().found)
            {
                isAgree = true;
            }
            else
            {
                isAgree = false;
            }
        }

        if (imHere)
        {
            if(!door.isOpen && isCanOpen && !one && !isAgree)
            {
                sourse.clip = openBot;
                boti.GetComponent<Bot>().openDoor = true;
                boti.GetComponent<Animator>().SetBool("OpenDoor", true);
                amDoor.SetBool("BotOpen", true);
                one = true;
            }
            if (!door.isOpen && isCanOpen && isAgree)
            {
                sourse.clip = crashDoor;
                boti.GetComponent<Bot>().openDoor = true;
                boti.GetComponent<Animator>().SetBool("OpenDoor", true);
                amDoor.SetTrigger("DestroyDoor");
                
            }
            imHere = false;
        }
        
        if (door.loked)
        {
            isCanOpen = false;
        }
        if (!door.loked && door.canUseDoor)
        {
            isCanOpen = true;
        }
    }

    public void DestroyDoor()
    {
        boti.GetComponent<Bot>().destDoor = true;
        dor2[0].SetActive(true);
        Destroy(dor2[1]);
        Destroy(gameObject);
    }

    public void OpenFalse()
    {
        amDoor.SetBool("BotOpen", false);
        one = false;
        door.isOpen = false;
    }
    public void OpenTrue()
    {
        door.isOpen = true;
        sourse.Play();
    }
}
