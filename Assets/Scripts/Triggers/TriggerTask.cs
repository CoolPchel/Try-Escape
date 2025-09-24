using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTask : MonoBehaviour
{
    public InfoTask taskComplit;
    public AllTask alltTask;
    public string infoTask;
    public bool isTriggerComplite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isTriggerComplite)
            {
                if (infoTask == "Я тут не один!")
                {
                    taskComplit.proverca = true;
                    taskComplit.nameComplitTask = "Я тут не один!";
                    Destroy(gameObject);
                }
            }
            if (infoTask == "Levl1 Bot")
            {
                alltTask.bot = true;
                Destroy(gameObject);
            }
        }
    }
}
