using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;


public class Bot : MonoBehaviour
{
    private Transform Tage;
    public GameObject bot;
    public bool Run = false;
    private Animator animach;
    //Добавить бота и время на охоту
    public NavMeshAgent age;
    public bool boolTime = false;
    public float time = 0f;
    public float maxtime = 5f;
    //Перемещение бота по точкам
    public bool next = false;
    public int rand;
    public List<Transform> Points;
    public float timeP = 0f;
    public float maxtimeP = 7f;
    //Глаза бота
    [Range(0,360)] public float ViewAngle = 90f;
    public float ViewDistance = 15f;
    public float DetectionDistance = 3f;
    public Transform Pleyer;
    public Transform EnemeEye;
    public bool found;
    public bool cant;
    //Двери
    public bool openDoor;
    public bool destDoor;

    public bool Iagree = true;
    public GameObject Camdie;
    public CameraDieScript camdietrue;

    public GameObject StepAudio;

    public AudioItems audioItems;

    public SoundRun souRunEnd;

    [SerializeField] AudioClip heart02;
    public AudioSource Sors;
    public GameObject scere;
    bool Yes;
    bool No;

    public void Start()
    {
        Tage = GetComponent<Transform>();
        age = GetComponent<NavMeshAgent>();
        animach = GetComponent<Animator>();
        RandomNomber();
    }

    //рандомайзер
    public void RandomNomber()
    {
        rand =  Random.Range(0, Points.Count);
    }
    //Если тригеры игрока и бота, коснулись друг друга, то игрок умерает.
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Camdie.SetActive(true);
            Tage.LookAt (Pleyer);
            camdietrue.Hedie = true;
        }
    }
    //Триггеры чтобы опредилить как сапустить казнь игроку
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trigger+")
        {
            camdietrue.Plys = true;
            camdietrue.Minus = false;
        }
        if (other.tag == "Trigger-")
        {
            camdietrue.Minus = true;
            camdietrue.Plys = false;
        }
        if (other.transform.tag == "Door")
        {
            CanOpenDoor cCanOpenDoor = other.GetComponent<CanOpenDoor>();
            cCanOpenDoor.imHere = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trigger+")
        {
            camdietrue.Plys = false;
        }
        if (other.tag == "Trigger-")
        {
            camdietrue.Minus = false;
        }
        if (other.transform.tag == "Door")
        {
            other.GetComponent<CanOpenDoor>().imHere = false;
        }
    }
    
    void Update()
    {
        //Сломал дверь
        if (destDoor)
        {
            animach.SetBool("OpenDoor", false);
            openDoor = false;
            destDoor = false;
        }
        if (openDoor)
        {
            age.speed = 0f;
        }
        //Доп время охоты после потери из виду
        if (boolTime)
        {
            time=time+Time.deltaTime;
            Runn();
            MoveToTarget();
            found = true;
        }
        //таймер Доп времени
        if (time >= maxtime)
        {
            boolTime = false;
            time = 0f;
        }
        //Время на смену точку(потруля)
        if (timeP >= maxtimeP)
        {
            next = true;
            timeP = 0f;
        }
        //Меняеться цель по точкам(потруля)
        if (next)
        {
            RandomNomber();
            next = false;
        }
        
        //Если бот увидит игрока или подойти заспину, то начнёться охота
        float distaneToPlayer = Vector3.Distance(Pleyer.transform.position, Tage.position);
        float realAngle = Vector3.Angle(EnemeEye.forward, Pleyer.position - EnemeEye.position);
        RaycastHit hit;
        if (Physics.Raycast(EnemeEye.transform.position, Pleyer.position - EnemeEye.position, out hit, ViewDistance, 1 << LayerMask.NameToLayer("Target")))
        {
            if (distaneToPlayer <= DetectionDistance || realAngle < ViewAngle / 2f && Vector3.Distance(EnemeEye.position, Pleyer.position) <= ViewDistance && hit.transform == Pleyer.transform && !cant)
            {
                if (Iagree)
                {
                    if (!openDoor)
                    {
                        age.speed = 6f;
                    }
                    Runn();
                    //StepAudio.GetComponent<AudioBots>().heMowe = false;
                    MoveToTarget();
                    found = true;
                    time = 0f;
                    boolTime = true;
                    No = false;
                    StepAudio.GetComponent<AudioBots>().heMowe = false;
                }
                if (Yes && !No)
                {
                    audioItems.startRun = true;
                    MPlay();
                    Yes = false;
                    Sors.volume = 0.7f;
                    scere.GetComponent<AudioScere>().Hunt = true;
                }
                cant = false;
            }
            else
            {
                cant = true;
            }
        }
        if (cant)
        {
            if (Physics.Raycast(EnemeEye.transform.position, Pleyer.position - EnemeEye.position, out hit, ViewDistance, 1 << LayerMask.NameToLayer("WallObject")))
            {
                cant = true;
            } 
            else
            {
                cant = false;
            }
        }
        //Окончание охоты
        if (!boolTime)
        {
            Camdie.SetActive(false);
            souRunEnd.GetComponent<SoundRun>().isTime = false;
            if (!openDoor)
            {
                age.speed = 3.5f;
            }
            found = false;
            scere.GetComponent<AudioScere>().DieClouse = false;
            Yes = true;
            No = true;
            Sors.volume = 0.5f;
            scere.GetComponent<AudioScere>().Hunt = false;
        }
        //Видить угл обзора бота
        DrawViewState();

        //Перемещение бота пока он не охотиться
        if (!found)
        {
            animach.SetTrigger("Fund");
            if (!openDoor)
            {
                Wolk();
            }
            //передвижение бота
            age.SetDestination(Points[rand].position);
        }

        //если он стоит на месете
        if (Tage.position.x == Points[rand].position.x)
        {
            Look();
            timeP=timeP+Time.deltaTime;
        }

        if (camdietrue.chek) //Чтобы бот изчес когда идет анимация смерти 
        {
            souRunEnd.GetComponent<SoundRun>().heDie = true;
            bot.SetActive(false); 
        }

        if (distaneToPlayer <= 6f)
        {
            Camdie.SetActive(true);
        }
        else
        {
            Camdie.SetActive(false);
        }
        Debug.DrawLine(EnemeEye.transform.position, Pleyer.position, Color.green);
    }   
    //глаза бота
    //охота
    private void MoveToTarget()
    {
        age.SetDestination(Pleyer.position);
        scere.GetComponent<AudioScere>().DieClouse = true;
        if (Yes && !No)
        {
            MPlay();
            Yes = false;
            scere.GetComponent<AudioScere>().Hunt = true;
        }
    }
    //Лазер
    private void DrawViewState()
    {
        Vector3 left = EnemeEye.position + Quaternion.Euler(new Vector3(0, ViewAngle / 2f, 0)) * (EnemeEye.forward * ViewDistance);
        Vector3 right = EnemeEye.position + Quaternion.Euler(-new Vector3(0, ViewAngle / 2f, 0)) * (EnemeEye.forward * ViewDistance);
        Debug.DrawLine(EnemeEye.position, left, Color.yellow);
        Debug.DrawLine(EnemeEye.position, right, Color.yellow);
    }

    void Wolk()
    {
        animach.SetBool("Mowe", true);
        animach.SetBool("IsStope", false);
        StepAudio.GetComponent<AudioBots>().heMowe = true;
        StepAudio.GetComponent<AudioBots>().heRun = false;
    }
    void Runn()
    {
        animach.SetTrigger("Run");
        StepAudio.GetComponent<AudioBots>().heRun = true;
        StepAudio.GetComponent<AudioBots>().heMowe = false;
    }
    void Look()
    {
        animach.SetBool("IsStope", true);
        animach.SetBool("Mowe", false);
        StepAudio.GetComponent<AudioBots>().heMowe = false;
        StepAudio.GetComponent<AudioBots>().heRun = false;
    }
    public void EndAm()
    {
        animach.SetBool("OpenDoor", false);
        openDoor = false;
    }

    public void MPlay()
    {
        Sors.clip = heart02;
        Sors.Play();
    }
}
