using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChekingProgeres : MonoBehaviour
{
    public List<GameObject> buttons;
    private float chek;

    public void Awake()
    {
        chek = PlayerPrefs.GetFloat("Progres");
        if(chek != 0f)
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(true);
            buttons[2].SetActive(true);
        }
        else
        {
            buttons[0].SetActive(true);
            buttons[1].SetActive(false);
            buttons[2].SetActive(false);
        }
    }
}
