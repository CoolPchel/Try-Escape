using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDForBots : MonoBehaviour
{
    public bool heOpen;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Scare")
        {
            heOpen = true;
        }
    }
}
