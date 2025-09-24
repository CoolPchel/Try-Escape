using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusik : MonoBehaviour
{
    public Musik musiki;
    public int numberi;
    public bool isDistroy;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            musiki.number = numberi;
            musiki.nextMusik = true;
            if (isDistroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
