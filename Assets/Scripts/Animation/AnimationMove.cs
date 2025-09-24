using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMove : MonoBehaviour
{
    //private FirstPersonMovement fPMi;
    private Animator am;
    private Collider pley;
    public bool noqe;

    public bool icanRun;

    void Start()
    {
        //fPMi = FindObjectOfType<FirstPersonMovement>();
        am = GetComponent<Animator>();
        pley = GetComponent<Collider>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "wol" || other.transform.tag == "Door" || other.transform.tag == "DoorGreen" || other.transform.tag == "DoorRed" || other.transform.tag == "DoorOrange")
        {
            noqe = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "wol" || other.transform.tag == "Door" || other.transform.tag == "DoorGreen" || other.transform.tag == "DoorRed" || other.transform.tag == "DoorOrange")
        {
            noqe = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            am.SetBool("isMouve", true);
        }
        else
        {
            am.SetBool("isMouve", false);
        }
        if (Input.GetKey(KeyCode.LeftShift) && icanRun && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) && icanRun && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftShift) && icanRun && Input.GetKey(KeyCode.D))
        {
            am.SetBool("isRun", true);
        }
        if (!icanRun || !Input.GetKey(KeyCode.LeftShift))
        {
            am.SetBool("isRun", false);
        }
        if (Input.GetKey(KeyCode.E) && !noqe)
        {
            am.SetBool("RightLook", true);
        }
        else
        {
            am.SetBool("RightLook", false);
        }
        if (Input.GetKey(KeyCode.Q) && !noqe)
        {
            am.SetBool("LeftLook", true);
        }
        else
        {
            am.SetBool("LeftLook", false);
        }
    }
    
}
