using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChek : MonoBehaviour
{
    public CameraDieScript camDie;
    public CheckPoint proverki;
    public AllTask alTask;
    public string proverka;
    public bool save1;
    public List<Sechik> setchik;
    public List<GameObject> items;
    public List<GameObject> ob;
    public int energyint = 0;
    public int fonarikint = 0;
    public int keyint = 0;
    public int buttoryint = 0;

    void Awake()
    {
        energyint = PlayerPrefs.GetInt("Energy");
        fonarikint = PlayerPrefs.GetInt("Fonarik");
        keyint = PlayerPrefs.GetInt("KeyRed");
        buttoryint = PlayerPrefs.GetInt("Buttory");
        proverka = PlayerPrefs.GetString("Chek");
        if(proverka == "true")
        {
            save1 = true;
            proverki.restart = true;
            camDie.StartAm = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(save1)
        {
            ob[0].SetActive(true);
            ob[1].SetActive(true);
            setchik[0].noKnob = false;
            setchik[1].activ = true;
            if(energyint > 0)
            {
                items[0].SetActive(true);
                energyint--;
            }
            if(fonarikint > 0)
            {
                items[1].SetActive(true);
                fonarikint--;
            }
            if(keyint > 0)
            {
                items[2].SetActive(true);
                keyint--;
            }
            if(buttoryint > 0)
            {
                items[3].SetActive(true);
                buttoryint--;
            }
            if(proverki.meYes)
            {
                alTask.redDoor = true;
            }
            alTask.startGame = true;
            save1 = false;
        }
    }
}
