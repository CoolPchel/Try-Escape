using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBotLevel1 : MonoBehaviour
{
    public Sechik sechikk;
    private Animator ami;

    void Start()
    {
        ami = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sechikk.activ)
        {
            ami.SetTrigger("StartShow");
        }
    }

    public void DestroyHere()
    {
        Destroy(gameObject);
    }
}
