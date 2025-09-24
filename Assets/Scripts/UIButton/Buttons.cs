using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //Нужно использовать если в скрипте используються сцены
using UnityEngine;

//Скрипт отвечает за кнопки

public class Buttons : MonoBehaviour
{
    public LoadingGame lGame;
    public GameObject lamp;
    public Animator amik;
    public Animator amiBut;

    public void RestartGame() //При нажатии на рестарт, происходит звук и презагружаеться сцена
    {
        SceneManager.LoadScene(1); //Можно написать имя сцены или порядок сцен в меню настроек
    }
    
    public void SettingAm()
    {
        amik.SetBool("GoIn", true);
    }
    public void DiSettingAm()
    {
        amik.SetBool("GoIn", false);
    }
    public void StartNewGame()
    {
        lGame.number = 1;
        lamp.GetComponent<Animator>().SetTrigger("NewGame");
        lamp.GetComponent<AudioSource>().Play();
        amik.SetTrigger("SNewGame");
    }
    public void Load()
    {
        amiBut.SetTrigger("But");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
