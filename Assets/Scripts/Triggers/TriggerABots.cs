using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerABots : MonoBehaviour
{
    public GameObject bot;
    public bool isDestroy;
    public bool botActive;

    public void Start()
    {
        if(!botActive)
        {
            bot.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            botActive = true;
            bot.SetActive(true);
            if (isDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
