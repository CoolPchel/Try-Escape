using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsOnTriggers : MonoBehaviour
{
    [SerializeField] AudioClip stepOnWood;
    [SerializeField] AudioClip runOnWood;
    [SerializeField] AudioClip stepAndRunOnGraz;
    public FirstPersonAudio fpa;

    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "FlorWood")
        {
            fpa.stepAudio.clip = stepOnWood;
            fpa.runningAudio.clip = runOnWood;
            fpa.runningAudio.pitch = 1f;
        }
        if (other.transform.tag == "FlorGraz")
        {
            fpa.stepAudio.clip = stepAndRunOnGraz;
            fpa.runningAudio.clip = stepAndRunOnGraz;
            fpa.runningAudio.pitch = 1.5f;
        }
    }

    void Update()
    {
    }
}
