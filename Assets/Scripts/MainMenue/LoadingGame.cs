using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingGame : MonoBehaviour
{
    public CheckPoint levChek;
    public int number;
    public Animator cherep;
    public GameObject LoadingScreen;
    public TextMeshProUGUI texti;
    private string redy = "Готово! Нажмите на любую кнопку чтобы продолжить!";
    public Slider bar;
    private float shetatel;

    public void NewGame()
    {
        //if(PlayerPrefs.HasKey("Progres"))
        //{
            //PlayerPrefs.DeleteKey("Progres");
        //}
        number = 1;
        LoadingScreen.SetActive(true);
        AudioListener.pause = true;
        StartCoroutine(LoadAsync());
    }

    public void Load()
    {
        //shetatel = PlayerPrefs.GetFloat("Progres");
        //if (shetatel < 2f && shetatel >= 1f)
        //{
        number = 1;
        //}
        LoadingScreen.SetActive(true);
        AudioListener.pause = true;
        StartCoroutine(LoadAsync());
    }

    public void Restart()
    {
        number = 1;
        LoadingScreen.SetActive(true);
        AudioListener.pause = true;
        StartCoroutine(LoadAsync());
    }

    public void ExitMenue()
    {
        number = 0;
        LoadingScreen.SetActive(true);
        AudioListener.pause = true;
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(number);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;

            if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                cherep.SetTrigger("ready");
                texti.text = redy;
                bar.value = 10;
                if(Input.anyKeyDown)
                {
                    AudioListener.pause = false;
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
