using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioItems : MonoBehaviour
{
    public bool playAudioQE;

    [SerializeField] AudioClip heSeeMe;
    public SoundRun souRun;
    public bool startRun = false;

    private AudioSource aSI;
    [SerializeField] AudioClip useCan;
    [SerializeField] AudioClip useKey;
    [SerializeField] AudioClip useFonaric;
    [SerializeField] AudioClip useButtery;
    [SerializeField] AudioClip useBMetal;
    public bool isBMetal = false;
    public bool isFonarik = false;
    public bool isButtory = false;
    public bool isCan = false;
    public bool isKey = false;


    void Start()
    {
        aSI = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ЖелезнаяБанка
        if (isCan)
        {
            aSI.clip = useCan;
            aSI.Play();
            isCan = false;
        }
        //Ключи
        if (isKey)
        {
            aSI.clip = useKey;
            aSI.Play();
            isKey = false;
        }
        //Фонарик и батарейка
        if (isFonarik)
        {
            aSI.clip = useFonaric;
            aSI.Play();
            isFonarik = false;
        }
        if (isButtory)
        {
            aSI.clip = useButtery;
            aSI.Play();
            isButtory = false;
        }
        //Рубильник
        if (isBMetal)
        {
            aSI.clip = useBMetal;
            aSI.Play();
            isBMetal = false;
        }

        if (startRun)
        {
            aSI.clip = heSeeMe;
            souRun.GetComponent<SoundRun>().startSoundRun = true;
            aSI.Play();
            startRun = false;
        }
        
        if (playAudioQE)
        {
            aSI.Play();
            playAudioQE = false;
        }

    }
}
