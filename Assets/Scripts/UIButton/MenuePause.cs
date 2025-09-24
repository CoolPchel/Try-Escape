using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Скрипт управляет пузой

public class MenuePause : MonoBehaviour
{
    public LoadingGame lGamee;
    public FirstPersonLook fPL;
    public bool pauseGame = false; 
    public GameObject pauseGameMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        AudioListener.pause = false; //Вкл все звуки сцены
        fPL.sensitivity = 2f; //Разрешаю вертеть камерой
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; //Востанавливает время
        pauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        AudioListener.pause = true; //Выкл все звуки сцены
        fPL.sensitivity = 0f; //Запрещаю вертеть камерой
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; //Остонавливает время
        pauseGame = true;
    }
    public void LostMenu()
    {
        lGamee.number = 0;
        pauseGameMenu.SetActive(false); //
        AudioListener.pause = false;
        fPL.sensitivity = 2f; //
        Time.timeScale = 1f;
    }
}
