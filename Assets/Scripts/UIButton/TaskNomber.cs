using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Для родитеял Ui элементов

public class TaskNomber : MonoBehaviour
{
    public string texti; // получает описание задания
    public string nameTeski;
    public GameObject persorm; //галочка
    public GameObject toggle; //родитель галочки
    public TextMeshProUGUI finalText; // показывает текст
    public bool haveTack; //Обозначет для родителя имет ли задание
    public bool compliteMision;

    void Start()
    {    
        toggle.SetActive(false);
        finalText.text = texti.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (haveTack)
        {
            toggle.SetActive(true);
            persorm.SetActive(false);
            finalText.text = texti.ToString();// финальный этап получения текста
        }
        if (compliteMision)
        {
            persorm.SetActive(true);
        }

    }
}
