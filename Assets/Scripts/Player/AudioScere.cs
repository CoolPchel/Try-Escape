using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AudioScere : MonoBehaviour
{
    private AudioSource Sors;
    [SerializeField] public AudioClip heart;
    private bool Yes;
    private bool No;
    public Image[] imageScere;
    public Sprite[] spritsScere;
    public Image ScereUI;
    private float ScereFloat = 0f;
    public bool Hunt;
    public Transform botik;
    public bool DieClouse = false;

    float time = 0f;

    void Start()
    {
        Sors = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, botik.position) <= 9f || DieClouse)
        {
            No = false;
            ScereFloat = ScereFloat + 0.5f * Time.deltaTime;
            time = time+Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, botik.position) > 9f)
        {
            Yes = true;
            No = true;
            ScereFloat = ScereFloat - 0.5f * Time.deltaTime;
        }
        if (Yes && !No)
        {
            MPlay();
            Yes = false;
        }
        if (Yes && No && !Hunt)
        {
            MStop();
        }
        if (ScereFloat <= -0.5f)
        {
            ScereFloat = 0f;
        }
        if (ScereFloat >= 2.3f)
        {
            ScereFloat = 2f;
        }
        if (time >= 0.5f)
        {
            AmScere();
            time = 0f;
        }
        ScereUI.GetComponent<Image>().color = new Color(255f, 255f, 255f, ScereFloat);
    }

    void AmScere()
    {
        int RandomScre = Random.Range(0, 4);
        imageScere[0].sprite = spritsScere[RandomScre];
    }

    public void MPlay()
    {
        Sors.clip = heart;
        Sors.Play();
    }

    public void MStop()
    {
        Sors.Stop();
    }
}
