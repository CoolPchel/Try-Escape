using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musik : MonoBehaviour
{
    [SerializeField] List<AudioClip> musik;
    private AudioSource sorMusik;
    public int number = 0;
    public bool nextMusik;
    private float crom = 1f;
    private int next = 0;

    void Start()
    {
        sorMusik = GetComponent<AudioSource>();
    }

    void Update()
    {
        sorMusik.volume = crom;

        if(nextMusik)
        {
            if (sorMusik.volume >= 0f && next == 0)
            {
                crom = crom - 0.3f * Time.deltaTime;
                if (crom <= 0f)
                {
                    sorMusik.clip = musik[number];
                    sorMusik.Play();
                    next = 1;
                }
            }
            if (sorMusik.volume <= 1f && next == 1)
            {
                crom = crom + 0.3f * Time.deltaTime;
                if (crom >= 1f)
                {
                    next = 2;
                }
            }
            if (next == 2)
            {
                nextMusik = false;
            }
        }
        if (!nextMusik)
        {
            next = 0;
        }
    }
}
