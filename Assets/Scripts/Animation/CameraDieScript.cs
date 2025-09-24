using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraDieScript : MonoBehaviour
{
    [SerializeField] AudioClip startAmi;
    public bool StartAm;
    public Camera MeinCam;
    public List<GameObject> Ui;
    Animator am;
    public bool Hedie = false;
    public bool chek = false;
    private int digit = 0;

    AudioSource sour;
    bool soudie = false;
    bool soudkill = false;
    public bool bitdie = false;
    [SerializeField] AudioClip KillBot;
    [SerializeField] AudioClip killbackBot;
    [SerializeField] AudioClip KillByly;
    [SerializeField] AudioClip KillbackByly;
    public bool Plys = false;
    public bool Minus = false;
    public bool byly = false;
    [SerializeField] AudioClip DieSoundBot;
    [SerializeField] AudioClip DieSoundBackBot;

    // Start is called before the first frame update
    void Start()
    {
        sour = GetComponent<AudioSource>();
        am = GetComponent<Animator>();
        if (StartAm)
        {
            am.SetTrigger("StartLevel");
            sour.clip = startAmi;
            StartAm = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Проверка как умер игрок
        if (Hedie && Minus && !Plys)
        {
            MeinCam.depth = -2;
            soudkill = true;
            am.SetTrigger("hiDieBackBot");
            chek = true;// Даёт подверждение боту
            for (int i = 0; i < Ui.Count; i++)
            {
                Ui[i].SetActive(false);

            }
        }
        if (Hedie && Plys && !byly && !Minus) 
        {
            MeinCam.depth = -2;
            soudkill = true;
            am.SetTrigger("hiDieBot");
            chek = true;// Даёт подверждение боту
            for (int i = 0; i < Ui.Count; i++)
            {
                Ui[i].SetActive(false);
            }
        }
        if (Hedie && byly && !Plys)
        {
            MeinCam.depth = -2;
            am.SetTrigger("hiDieByly");
            chek = true; // Даёт подверждение боту
            for (int i = 0; i < Ui.Count; i++)
            {
                Ui[i].SetActive(false);
            }
        }
        if (Hedie && Plys && byly)
        {
            MeinCam.depth = -2;
            am.SetTrigger("hiDieBylyButNo");
            chek = true;// Даёт подверждение боту
            for (int i = 0; i < Ui.Count; i++)
            {
                Ui[i].SetActive(false);
            }
        }
        //Звук смерти
        if (Hedie && Plys && !byly && soudkill && !soudie && !Minus)
        {
            sour.clip = KillBot;
            sour.Play();
            digit = 1;
            soudkill = false;
            soudie = true;
        }
        if (Hedie && Minus && !byly && soudkill && !soudie && !Plys)
        {
            sour.clip = killbackBot;
            sour.Play();
            digit = 2;
            soudkill = false;
            soudie = true;
        }
        //Звук UI смерти
        if (bitdie && digit == 1)
        {
            sour.clip = DieSoundBot;
            sour.Play();
            print("bitdie");
            bitdie = false;
        }
        if (bitdie && digit == 2)
        {
            sour.clip = DieSoundBackBot;
            sour.Play();
            print("bitdie");
            bitdie = false;
        }
    }
    public void StartAmGame()
    {
        sour.Play();
    }
}
