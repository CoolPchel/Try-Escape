using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Скрипт надеваеться на родителя всех UI заданий

public class Task : MonoBehaviour
{
    public InfoTask inf;
    public GameObject tAndScroll;
    public MenuePause mPause;
    public List<GameObject> perfarm; //Список UI заданий
    public string text; //получения нужного текста
    public string nameTaskText;
    private string nullText = ""; //Очищает полученый текст для следующего текста
    public bool give1Tack = false; //Даёт текст только один раз
    public bool chendg;
    public string nameComTask;

    void Update()
    {
        for(int i = 0; i < perfarm.Count; i++)
        {
            if (perfarm[i].GetComponent<TaskNomber>().haveTack == false) //Если UI текст не имеет заданий
            {
                if (give1Tack)
                {
                    perfarm[i].GetComponent<TaskNomber>().texti = text; //2 этап передования текста
                    perfarm[i].GetComponent<TaskNomber>().nameTeski = nameTaskText;
                    perfarm[i].GetComponent<TaskNomber>().haveTack = true; //Даёт знак что имеет теперь задание
                    text = nullText;//Очищает текст
                    give1Tack = false;
                }
                else
                {
                    perfarm[i].GetComponent<TaskNomber>().texti = text;
                    perfarm[i].GetComponent<TaskNomber>().nameTeski = text; 
                }
            }
            if (perfarm[i].GetComponent<TaskNomber>().haveTack == true)
            {
                if (chendg)
                {
                    if (perfarm[i].GetComponent<TaskNomber>().nameTeski == "Оранжевая дверь" && nameComTask == "Оранжевая дверь")
                    {
                        perfarm[i].GetComponent<TaskNomber>().compliteMision = true;
                        nameComTask = nullText;
                        inf.complite = true;
                        chendg = false;
                    }
                    if (perfarm[i].GetComponent<TaskNomber>().nameTeski == "Красная дверь" && nameComTask == "Красная дверь")
                    {
                        perfarm[i].GetComponent<TaskNomber>().compliteMision = true;
                        nameComTask = nullText;
                        inf.complite = true;
                        chendg = false;
                    }
                    if (perfarm[i].GetComponent<TaskNomber>().nameTeski == "Зелёная дверь" && nameComTask == "Зелёная дверь")
                    {
                        perfarm[i].GetComponent<TaskNomber>().compliteMision = true;
                        nameComTask = nullText;
                        inf.complite = true;
                        chendg = false;
                    }
                    if (perfarm[i].GetComponent<TaskNomber>().nameTeski == "Рубильник" && nameComTask == "Рубильник")
                    {
                        perfarm[i].GetComponent<TaskNomber>().compliteMision = true;
                        nameComTask = nullText;
                        inf.complite = true;
                        chendg = false;
                    }
                    if (perfarm[i].GetComponent<TaskNomber>().nameTeski == "Я тут не один!" && nameComTask == "Я тут не один!")
                    {
                        perfarm[i].GetComponent<TaskNomber>().compliteMision = true;
                        nameComTask = nullText;
                        inf.complite = true;
                        chendg = false;
                    }
                }
            }
        }
        
        if (mPause.pauseGame)
        {
            tAndScroll.SetActive(true);
        }
        else
        {
            tAndScroll.SetActive(false);
        }
    }
}
