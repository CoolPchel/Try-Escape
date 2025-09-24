using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffSounds : MonoBehaviour
{
    private AudioSource audi;
    public bool stirti; 
    private float i = 0.5f;

    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(stirti && i >= 0f)
        {
            i = i - 0.1f * Time.deltaTime;
            audi.volume = i;
        }
    }
}
