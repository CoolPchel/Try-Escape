using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class BotByly : MonoBehaviour
{
    public GameObject fire;
    public GameObject im;
    public GameObject Camdie;
    Transform Tage;
    Animator animach;
    NavMeshAgent age;
    //Перемещение бота по точкам
    bool next = false;
    public int rand;
    public List<Transform> Points;
    public float timeP = 0f;
    float maxtimeP = 9f;
    public Transform Pleyer;
    bool Iagree = false;
    bool CanKill = false;
    bool PraviloKill = false;
    
    public void Start()
    {
        Tage = GetComponent<Transform>();
        age = GetComponent<NavMeshAgent>();
        animach = GetComponent<Animator>();
        RandomNomber();
        Wolk();
    }

    //рандомайзер
    public void RandomNomber()
    {
        rand =  Random.Range(0, Points.Count);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!CanKill)
            {
                im.SetActive(false);
                Camdie.GetComponent<CameraDieScript>().byly = true;
                Camdie.GetComponent<CameraDieScript>().Hedie = true;
                fire.SetActive(false); 
            }
        }
        if (other.transform.tag == "Trigger+")
        {
            Camdie.GetComponent<CameraDieScript>().Plys = true;
        }
        if (other.transform.tag == "fire")
        {
            age.stoppingDistance = 1;
            ScereFire();
            Wolk();
            age.speed = 3f;
            if (PraviloKill)
            {
                CanKill = true;
            }
            age.SetDestination(Points[rand].position);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "fire")
        {
            age.stoppingDistance = 0;
            next = true;
            PraviloKill = false;
            CanKill = false;
        }
        if (other.transform.tag == "Trigger+")
        {
            Camdie.GetComponent<CameraDieScript>().Plys = false;
        }
    }
   
    void Update()
    {
        if (timeP >= maxtimeP)
        {
            Iagree = true;
            timeP = 0f;
        }
        //Меняеться цель по точкам(потруля)
        if (next)
        {
            Wolk();
            RandomNomber();
            next = false;
        }

        if (Iagree)
        {
            RunToTarget();
        }
        else
        {
            age.SetDestination(Points[rand].position);
        }

        if (Tage.position.x == Points[rand].position.x)
        {
            Idl();
            timeP=timeP+Time.deltaTime;
        }
    }   

    private void RunToTarget()
    {
        Run();
        PraviloKill = true;
        age.SetDestination(Pleyer.position);
        age.speed = 9f;
    }
    void ScereFire()
    {
        isfire();
        Iagree = false;
    }

    void Idl()
    {
        animach.SetBool("IsWolk", false);
        animach.SetBool("IsRun", false);
    }
    void Wolk()
    {
        animach.SetBool("IsWolk", true);
        animach.SetBool("IsRun", false);
    }
    void Run()
    {
        animach.SetBool("IsFire", false);
        animach.SetBool("IsRun", true);
        animach.SetBool("IsWolk", false);
    }
    void isfire()
    {
        animach.SetBool("IsFire", true);
    }
}
