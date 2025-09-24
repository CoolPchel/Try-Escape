using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//Этот срипт нужен как класс для всех придметов которые будут в игре

//Создаём инфу подгруппу придметов (еда, оруж или т.т.)
public enum ItemType {BuffEffect, ObjectSyshet}

//Создаём общую инфу об придметах
public class ItemScriptableObject : ScriptableObject 
{
    
    
    public string itemName; //имя предмета
    public int maximumAmount; //Стакаеться ли придмет
    public GameObject itemPrefab; // 3D префаб придмета
    public Sprite icon; //Иконка предмета
    public ItemType itemType; //тип обьекта
    public bool isBuff; //Определяет предмет с эфектами лии нет
    public string itemDescription; //описание предмета
    public string inHandName; //Имя обьекта(префаба) в руке

    [Header("Consumable Characteristics")] // чтобы отлечать что они делают
    public float changeStamina; //предмет даёт доп выносливость
    
}
