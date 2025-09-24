using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learning : MonoBehaviour
{
    public FirstPersonLook fPLi;
    public List<GameObject> tabs;
    public List<GameObject> dop;
    public bool startGame;
    private bool endLearning;
    private int step = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (startGame)
        {
            tabs[0].SetActive(true);
            fPLi.sensitivity = 0f; //Запрещаю вертеть камерой
            Cursor.lockState = CursorLockMode.None;
            startGame = false;
        }
        if (!endLearning)
        {
            if (step == 1)
            {
                tabs[1].SetActive(true);
            }
            if (step == 2)
            {
                tabs[1].SetActive(false);
                tabs[2].SetActive(true);
            }
            if (step == 3)
            {
                tabs[1].SetActive(false);
                tabs[2].SetActive(false);
                tabs[3].SetActive(true);
            }
            if (step == 4)
            {
                tabs[1].SetActive(false);
                tabs[2].SetActive(false);
                tabs[3].SetActive(false);
                tabs[4].SetActive(true);
            }
        }
        if (endLearning)
        {
            Destroy(gameObject);
        }
        if (dop[0].GetComponent<OnOffLight>().off || dop[1].GetComponent<Doors>().ay)
        {
            step = 2;
        }
        if (dop[2].GetComponent<PickUpItems>().eb)
        {
            step = 3;
        }
        if (dop[3].GetComponent<QuickslotInventory>().activeSlot != null)
        {
            step = 4;
        }
        if (dop[4].GetComponent<Task>().chendg)
        {
            endLearning = true;
        }
    }
    public void LeardingStep()
    {
        step++;
        fPLi.sensitivity = 2f; //Разрешаю вертеть камерой
        Cursor.lockState = CursorLockMode.Locked;
    }
}
