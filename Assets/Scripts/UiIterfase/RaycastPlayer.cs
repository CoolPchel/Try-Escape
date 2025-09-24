using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlayer : MonoBehaviour
{
    private Camera cameraPlayer;
    private float distensray = 3f;
    private QuickslotInventory quickslot;

    void Start()
    {
        quickslot = FindObjectOfType<QuickslotInventory>();
        cameraPlayer = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraPlayer.transform.position, cameraPlayer.transform.forward, out hit, distensray))
        {
            if(hit.transform.tag == "DoorGreen")
            {
                quickslot.keyCanUse = true;
                quickslot.colorGreen = true;
                quickslot.colorOrange = false;
                quickslot.colorRed = false;
            }
            if(hit.transform.tag == "DoorRed")
            {
                quickslot.keyCanUse = true;
                quickslot.colorRed = true;
                quickslot.colorOrange = false;
                quickslot.colorGreen = false;
            }
            if(hit.transform.tag == "DoorOrange")
            {
                quickslot.keyCanUse = true;
                quickslot.colorOrange = true;
                quickslot.colorRed = false;
                quickslot.colorGreen = false;
            }
            if(hit.transform.tag != "DoorOrange" && hit.transform.tag != "DoorRed" && hit.transform.tag != "DoorGreen")
            {
                quickslot.keyCanUse = false;
            }
            //Рубильник
            if(hit.transform.tag == "Switch")
            {
                quickslot.knobCanUse = true;
            }
            else
            {
                quickslot.knobCanUse = false;
            }
        }
    }
}
