using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Sechik setchik;
    public GameObject falseObject;
    public GameObject trueObject;
    public bool zabor = false;
    public bool light = false;
    private bool doble = true;
    private bool lechGo = false;
    private Animator animation;
    public AudioSource asZabor;
    [SerializeField] AudioClip activ;

    void Start()
    {
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        if (zabor)
        {
            if(setchik.activ)
            {
                lechGo = true;
                animation.SetTrigger("isOpen");
            }
        }
        if (light)
        {
            if(setchik.activ)
            {
                falseObject.SetActive(false);
                trueObject.SetActive(true);
            }
        }   
        if (lechGo && doble)
        {
            asZabor.clip = activ;
            asZabor.Play();
            doble = false;
        }
    }
}
