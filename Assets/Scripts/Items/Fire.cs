using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Light fire;
    public int moment = 10;
    public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0.1)
        {
            moment =  Random.Range(10, 13);
            time = 0f;
        }
        time = time + Time.deltaTime;
        fire.GetComponent<Light>().intensity = moment;
    }
}
