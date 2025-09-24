using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот скрипт имеет все задание в этой игре

public class AllTask : MonoBehaviour
{
    public CheckPoint cheki;

    public string nameTask = "";
    public Task taskGiver; //Куда отдавать текст
    public InfoTask infotaski;
    public bool startGame = true;
    public bool oredgeDoor = false;
    public bool redDoor = false;
    public bool greenDoor = false;
    public bool knob = false;
    public bool bot = false;

    void Update()
    {
        if (startGame)
        {
            nameTask = "Начало игры";
            taskGiver.text = "Разобраться что здесь проиcходит";
            taskGiver.nameTaskText = nameTask;
            taskGiver.give1Tack = true;
            infotaski.OneT = true;
            nameTask = "";
            startGame = false;
        }
        if (oredgeDoor)
        {
            nameTask = "Оранжевая дверь";
            taskGiver.text = "Нужно найти <color=orange>оранжевый</color> ключ и открыть дверь";
            taskGiver.nameTaskText = nameTask;
            taskGiver.give1Tack = true;
            infotaski.OneT = true;
            nameTask = "";
            oredgeDoor = false;
        }
        if (redDoor)
        {
            nameTask = "Красная дверь";
            taskGiver.text = "Нужно найти <color=red>красный</color> ключ и открыть дверь";
            taskGiver.nameTaskText = nameTask;
            taskGiver.give1Tack = true;
            infotaski.OneT = true;
            nameTask = "";
            cheki.meYes = true;
            redDoor = false;
        }
        if (greenDoor)
        {
            nameTask = "Зелёная дверь";
            taskGiver.text = "Нужно найти <color=green>зелёный</color> ключ и открыть дверь";
            taskGiver.nameTaskText = nameTask;
            taskGiver.give1Tack = true;
            infotaski.OneT = true;
            nameTask = "";
            greenDoor = false;
        }
        if (knob)
        {
            nameTask = "Рубильник";
            taskGiver.text = "Нужно найти <color=grey>рубильник</color> и запитать ворота";
            taskGiver.nameTaskText = nameTask;
            taskGiver.give1Tack = true;
            infotaski.OneT = true;
            nameTask = "";
            knob = false;
        }
        if (bot)
        {
            nameTask = "Я тут не один!";
            taskGiver.text = "Не поподаться на глаза этому существу";
            taskGiver.nameTaskText = nameTask;
            taskGiver.give1Tack = true;
            infotaski.OneT = true;
            nameTask = "";
            bot = false;
        }
    }
}
