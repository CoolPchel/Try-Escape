using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBots : MonoBehaviour
{
    public AudioSource stepAudio;
    public AudioSource runAudio;
    private AudioSource oxyonAudio;
    public bool heMowe;
    public bool heRun;
    private bool wolk;

    [SerializeField] AudioClip Idl;
    [SerializeField] AudioClip Runoxyon;
    bool isSoundRun;
    bool isSoundWalk;

    void Start()
    {
        oxyonAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "FlorWood")
        {
            stepAudio.Play();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        //ходьба
        if (!isSoundWalk && heMowe && !heRun)
        {
            oxyonAudio.clip = Idl;
            wolk = true;
            heRun = false;
            runAudio.Stop();
            stepAudio.Play();
            oxyonAudio.Play();
            isSoundWalk = true;
        }
        if (!heMowe && wolk)
        {
            stepAudio.Stop();
            wolk = false;
            isSoundWalk = false;
        }
        //бег
        if (!isSoundRun && heRun && !heMowe)
        {
            oxyonAudio.clip = Runoxyon;
            heMowe = false;
            stepAudio.Stop();
            runAudio.Play();
            oxyonAudio.Play();
            isSoundRun = true;
        }
        if (!heRun)
        {
            runAudio.Stop();
            isSoundRun = false;
        }
        //scream
        
    }
}
