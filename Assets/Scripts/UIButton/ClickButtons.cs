using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButtons : MonoBehaviour
{
    [SerializeField] AudioClip Click;
    [SerializeField] AudioClip leaveMenue;
    [SerializeField] AudioClip tryagain;
    public void PlayAudio()
    {
        GetComponent<AudioSource>().ignoreListenerPause = true;
        GetComponent<AudioSource>().PlayOneShot(Click);
    }
    public void GoMenue()
    {
        GetComponent<AudioSource>().PlayOneShot(leaveMenue);
    }
    public void TryAgain()
    {
        GetComponent<AudioSource>().PlayOneShot(tryagain);
    }
}
