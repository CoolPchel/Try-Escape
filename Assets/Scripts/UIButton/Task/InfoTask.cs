using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTask : MonoBehaviour
{
    public Task taski;
    public Animator am;
    public TextMeshProUGUI amText;
    public bool complite;
    public string nameComplitTask;
    public bool OneT;
    public bool proverca;

    void Update()
    {
        if (proverca)
        {
            taski.chendg = true;
            taski.nameComTask = nameComplitTask;
            proverca = false;
        }
        if (complite)
        {
            amText.text = "Цель выполнена!".ToString();
            am.SetTrigger("ShowAm");
            complite = false;
        }
        if (taski.give1Tack && OneT)
        {
            amText.text = "Новоя цель!".ToString();
            am.SetTrigger("ShowAm");
            OneT = false;
        }
        

    }
}
