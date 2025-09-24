using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool restart;
    public Transform point;
    private Transform palyer;
    public float index;
    public List<InventorySlot> slots;
    public FlashLight fonar;
    public bool meYes;

    void Awake()
    {
        palyer = GameObject.FindGameObjectWithTag("Player").transform;
        if (DataContainer.checkpointIndex == index)
        {
            palyer.position = point.position;
        }
    }

    void Update()
    {
        if(restart)
        {
            if (DataContainer.checkpointIndex == index)
            {
                palyer.position = point.position;
            }
            restart = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(index > DataContainer.checkpointIndex)
            {
                PlayerPrefs.SetFloat("Progres", index);
                PlayerPrefs.SetString("Chek", "true");
                PlayerPrefs.SetInt("Buttory", fonar.col);
            }
            for(int i = 0; i < slots.Count; i++)
            {
                if(!slots[i].isEmpty)
                {
                    if(slots[i].item.name == "Drink Buff Stamin")
                    {
                        PlayerPrefs.SetInt("Energy", 1);
                    }
                    if(slots[i].item.name == "Fonarik")
                    {
                        PlayerPrefs.SetInt("Fonarik", 1);
                    }
                    if(slots[i].item.name == "KeyRed")
                    {
                        PlayerPrefs.SetInt("KeyRed", 1);
                    }
                }
            }
        }
    }
}
