using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRun : MonoBehaviour
{
    private AudioSource aSR;
    [SerializeField] AudioClip runSound;
    public bool isTime = false;
    private float volumeSound = 0f;
    public bool startSoundRun = false;
    public bool heDie = false;

    // Start is called before the first frame update
    void Start()
    {
        aSR = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTime)
        {
            volumeSound = volumeSound + 0.07f * Time.deltaTime;
        }
        if (!isTime && !heDie)
        {
            volumeSound = volumeSound - 0.08f * Time.deltaTime;
        }
        aSR.volume = volumeSound;

        if (volumeSound >= 0.4f)
        {
            volumeSound = 0.35f;
        }
        if (volumeSound <= -0.1f)
        {
            volumeSound = 0f;
        }

        if (heDie)
        {
            isTime = false;
            volumeSound = 0.1f;
        }

        if (startSoundRun)
        {
            aSR.clip = runSound;
            aSR.Play();
            isTime = true;
            startSoundRun = false;
        }
    }
}
