using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEmerge : MonoBehaviour
{
    public GameObject item;
    public List<Transform> point;
    private int digit = 0;

    void Start()
    {
        digit = Random.Range(0, point.Count);

        Instantiate(item, point[digit]);
    }
}
