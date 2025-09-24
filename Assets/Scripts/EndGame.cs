using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public List<AudioSource> light;
    public Animator amUiEnd;
    private float i = 4f;
    private bool yes;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            amUiEnd.SetBool("End", true);
            yes = true;
        }
    }

    void Update()
    {
        if(yes)
        {
            light[0].volume = i;
            light[1].volume = i;
            light[2].volume = i;
            light[3].volume = i;
            i = i - 0.1f * Time.deltaTime;
        }
        
    }
}
