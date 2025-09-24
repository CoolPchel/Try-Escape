using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlashLight : MonoBehaviour
{
    public Animator amPover;
    public AudioItems aitems;
    public bool isWork;
    public float puver = 100f;
    public bool nullPuver;
    public GameObject lightF;
    public List<GameObject> puverUI;
    public TextMeshProUGUI buttory;
    public int col = 0;


    void Update()
    {
        buttory.text = col.ToString();

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (col > 0 && puver != 100f)
            {
                aitems.isButtory = true;
                col--;
                amPover.SetBool("TenPover", false);
                amPover.SetTrigger("Null0");
                puver = 100f;
                isWork = false;
                nullPuver = false;
                puverUI[0].SetActive(true);
            }
        }

        if (puver >= 75f)
        {
            puverUI[3].SetActive(true);
            puverUI[2].SetActive(true);
            puverUI[1].SetActive(true);
            puverUI[0].SetActive(true);
        }
        if (puver <= 75f && puver >= 50f)
        {
            puverUI[3].SetActive(false);
            puverUI[2].SetActive(true);
            puverUI[1].SetActive(true);
            puverUI[0].SetActive(true);
        }
        if (puver <= 50f && puver >= 25f)
        {
            puverUI[3].SetActive(false);
            puverUI[2].SetActive(false);
            puverUI[1].SetActive(true);
            puverUI[0].SetActive(true);
        }
        if (puver <= 25f && puver >= 10f)
        {
            puverUI[3].SetActive(false);
            puverUI[2].SetActive(false);
            puverUI[1].SetActive(false);
            puverUI[0].SetActive(true);
        }

        if (puver <= 0f && !nullPuver)
        {
            nullPuver = true;
            isWork = false;
            amPover.SetBool("TenPover", false);
            amPover.SetBool("HavePover", false);
            lightF.SetActive(false);
            puverUI[0].SetActive(false);
        }
        
        if (puver > 0f)
        {
            amPover.SetBool("HavePover", true);
        }

        if(nullPuver)
        {
            puverUI[0].SetActive(false);
        }

        if (puver <= 10f && puver >= 0f)
        {
            amPover.SetBool("TenPover", true);
        }
        if (puver > 10f)
        {
            amPover.SetBool("TenPover", false);
        }

        if (isWork)
        {
            puver = puver - 1f * Time.deltaTime;
        }
        else
        {
            amPover.SetTrigger("Null0");
        }
        
        if (puver > 100f)
        {
            puver = 100f;
        }
    }
}
