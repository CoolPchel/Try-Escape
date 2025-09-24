using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventAMStartGame : MonoBehaviour
{
    public AllTask allT;
    public Learning learn;
    public List<GameObject> uiInterface;
    public AudioSource audiAm;
    public AudioSource audiMusik;
    public FirstPersonMovement fPMove;
    public FirstPersonLook fPLook;
    private float i = 0f;
    private float iM = 0f;
    private bool lestGo;

    void Start()
    {
        gameObject.SetActive(true);
        audiMusik.volume = iM;
        audiAm.volume = i;
    }
    // Update is called once per frame
    void Update()
    {
        if (lestGo && i <= 0.439f)
        {
            audiAm.volume = i;
            i = i + 0.1f * Time.deltaTime;
        }
        if (lestGo && iM <= 1f)
        {
            audiMusik.volume = iM;
            iM = iM + 0.1f * Time.deltaTime;
        }
    }

    public void StartLevelAm()
    {
        //AudioListener.pause = true;
        uiInterface[0].SetActive(false);
        uiInterface[1].SetActive(false);
        fPMove.speed = 0;
        fPMove.canRun = false;
        fPLook.sensitivity = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ReturneSLA()
    {
        uiInterface[0].SetActive(true);
        uiInterface[1].SetActive(true);
        fPMove.speed = 4;
        fPMove.canRun = true;
        fPLook.sensitivity = 1.5f;
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(false);
        learn.startGame = true;
        allT.startGame = true;
    }
    public void ReturneSound()
    {
        //AudioListener.pause = false;
        lestGo = true;
    }
}
