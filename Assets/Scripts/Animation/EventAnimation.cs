using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EventAnimation : MonoBehaviour
{
    public GameObject audioQE;
    [SerializeField] AudioClip startQE;
    [SerializeField] AudioClip endQE;

    public FlashLight fla;
    public GameObject lightFonarica;

    public GameObject fonMuisik;
    public GameObject sounRun;
    public GameObject GameObj;
    public GameObject camera;
    public GameObject player;
    public Animator am;
    public GameObject UiAm;

    //звуки
    public bool HeartOff;
    public Transform trueLight;
    public List<LightOffSounds> light = new List<LightOffSounds>();
    public List<AudioSource> audios;
    private float iRun = 0.1f;
    private float i = 0.5f;
    private bool yes;

    public LoadingGame loadScren;
    public GameObject amUiMeinMenue;

    void Awake()
    {
        if(HeartOff)
        {
            for (int f = 0; f < trueLight.childCount; f++)
            {
                if(trueLight.GetChild(f).GetComponent<LightOffSounds>() != null)
                {
                    light.Add(trueLight.GetChild(f).GetComponent<LightOffSounds>());
                }
            }
        }
    }

    void Update()
    {
        if (yes)
        {
            iRun = iRun - 0.02f * Time.deltaTime;
            i = i - 0.1f * Time.deltaTime;
            GameObj.GetComponent<AudioSource>().volume = i;
            sounRun.GetComponent<AudioSource>().volume = iRun;
            fonMuisik.GetComponent<AudioSource>().volume = iRun;
            for (int v = 0; v < light.Count; v++)
            {
                light[v].GetComponent<LightOffSounds>().stirti = true;
            }
            for (int e = 0; e < audios.Count; e++)
            {
                Destroy(audios[e]);
            }
        }
    }

    public void NullMCC()
    {
        player.GetComponent<FirstPersonMovement>().speed = 0;
        player.GetComponent<FirstPersonMovement>().canRun = false;
        camera.GetComponent<FirstPersonLook>().sensitivity = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ReturneMCC()
    {
        player.GetComponent<FirstPersonMovement>().speed = 4;
        player.GetComponent<FirstPersonMovement>().canRun = true;
        camera.GetComponent<FirstPersonLook>().sensitivity = 1.5f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RightLeftBlock()
    {
        audioQE.GetComponent<AudioSource>().clip = startQE;
        player.GetComponent<FirstPersonMovement>().speed = 0;
        player.GetComponent<FirstPersonMovement>().canRun = false;
        camera.GetComponent<FirstPersonLook>().sensitivity = 0;
        audioQE.GetComponent<AudioItems>().playAudioQE = true;
    }
    public void RightLeftReturn()
    {
        audioQE.GetComponent<AudioSource>().clip = endQE;
        player.GetComponent<FirstPersonMovement>().speed = 4;
        player.GetComponent<FirstPersonMovement>().canRun = true;
        camera.GetComponent<FirstPersonLook>().sensitivity = 2;
        audioQE.GetComponent<AudioItems>().playAudioQE = true;
    }
    public void GameOver()
    {
        player.GetComponent<FirstPersonMovement>().speed = 0;
        player.GetComponent<FirstPersonMovement>().canRun = false;
        camera.GetComponent<FirstPersonLook>().sensitivity = 0;
    }
    
    public void StartSound()
    {
        camera.GetComponent<CameraDieScript>().bitdie = true;
        camera.GetComponent<AudioSource>().volume = 0.7f;
    }

    public void OffHeart()
    {
        yes = true;
    }

    public void ReturnCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void EndAmBot1()
    {
        UiAm.GetComponent<Animator>().SetTrigger("TDieBot1");
    }
    public void EndAmBackBot()
    {
        UiAm.GetComponent<Animator>().SetTrigger("TDieBackBot");
    }

    public void SettingAmUi()
    {
        amUiMeinMenue.GetComponent<Animator>().SetBool("GoInUi", true);
    }
    public void DiSettingAmUi()
    {
        amUiMeinMenue.GetComponent<Animator>().SetBool("GoInUi", false);
    }
    public void LoadScene()
    {
        loadScren.Load();
    }

    public void ForPoverT()
    {
        if(fla.isWork && !fla.nullPuver)
        {
            lightFonarica.SetActive(true);
        }
    }
    public void ForPoverF()
    {
        if(fla.isWork && !fla.nullPuver)
        {
            lightFonarica.SetActive(false);
        }
    }
}
