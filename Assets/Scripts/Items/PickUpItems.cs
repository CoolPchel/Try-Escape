using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    AudioSource PUIsoud;
    public GameObject CamdieTr;
    public GameObject fireOn;
    public GameObject fireDown;
    public GameObject cameraPick;
    [SerializeField] AudioClip upKeys;
    [SerializeField] AudioClip upCan;
    [SerializeField] AudioClip upFonarik;
    [SerializeField] AudioClip upBigMetal;
    [SerializeField] AudioClip upLMettal;
    public bool oudioLMettal = false;
    public bool oudioFonarik = false;
    public bool oudioKey = false;
    public bool oudioCan = false;
    public bool oudioBMetal = false;
    //Для обучения
    public bool eb;

    void Start()
    {
        PUIsoud = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Scare")
        {
            CamdieTr.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Scare")
        {
            CamdieTr.SetActive(false);
        }
    }

    void Update()
    {
        if (oudioKey)
        {
            PUIsoud.clip = upKeys;
            PUIsoud.Play();
            eb = true;
            oudioKey = false;
        }
        if (oudioCan)
        {
            PUIsoud.clip = upCan;
            PUIsoud.Play();
            oudioCan = false;
        }
        if (oudioFonarik)
        {
            PUIsoud.clip = upFonarik;
            PUIsoud.Play();
            eb = true;
            oudioFonarik = false;
        }
        if (oudioBMetal)
        {
            PUIsoud.clip = upBigMetal;
            PUIsoud.Play();
            oudioBMetal = false;
        }
        if (oudioLMettal)
        {
            PUIsoud.clip = upLMettal;
            PUIsoud.Play();
            eb = true;
            oudioLMettal = false;
        }
    }
    //public void PickUp()
    //{
        //RaycastHit hit;
        //if(Physics.Raycast(cameraPick.transform.position, cameraPick.transform.forward, out hit, distance))
        //{
            //if(hit.transform.tag == "Item")
            //{
                //if (canPickUp) Drop();

                //PUIsoud.clip = Up;
                //Oudio = true;
                //currentWeapon = hit.transform.gameObject;
                //currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                //currentWeapon.GetComponent<Collider>().isTrigger = true;
                //currentWeapon.transform.parent = transform;
                //currentWeapon.transform.localPosition = Vector3.zero;
                
                //canPickUp = true;
                
            //}
            //if(hit.transform.tag == "fire")
            //{
                //fireDown.SetActive(false);
                //fireOn.SetActive(true);
            //}
        //}

        
    //}


    //public void Drop()
    //{
        //currentWeapon.transform.parent = null;
        //currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        //currentWeapon.GetComponent<Collider>().isTrigger = false;
        //canPickUp = false;
        //currentWeapon = null;
    //}

}
