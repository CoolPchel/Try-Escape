using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Этот скрип не нужно использовать как пример. Потому что я не правильно делаю, из за не опотности.
public class InfoObjact : MonoBehaviour
{
    public GameObject energyInfo;
    public GameObject greedKeyInfo;
    public GameObject redKeyInfo;
    public GameObject orangeKeyInfo;
    public GameObject fonarikInfo;
    public GameObject knobInfo;

    public bool energyItem = false;
    public bool greenKey = false;
    public bool redKey = false;
    public bool orangeKey = false;
    public bool fonarik = false;
    public bool knob = false;

    void Update()
    {
        //Энергетик
        if (energyItem)
        {
            energyInfo.SetActive(true);
        }
        else
        {
            energyInfo.SetActive(false);
        }
        //Ключи
        if (greenKey)
        {
            greedKeyInfo.SetActive(true);
        }
        else
        {
            greedKeyInfo.SetActive(false);
        }
        if (redKey)
        {
            redKeyInfo.SetActive(true);
        }
        else
        {
            redKeyInfo.SetActive(false);
        }
        if (orangeKey)
        {
            orangeKeyInfo.SetActive(true);
        }
        else
        {
            orangeKeyInfo.SetActive(false);
        }
        //Фонарик
        if (fonarik)
        {
            fonarikInfo.SetActive(true);
        }
        else
        {
            fonarikInfo.SetActive(false);
        }
        //Рубильник
        if (knob)
        {
            knobInfo.SetActive(true);
        }
        else
        {
            knobInfo.SetActive(false);
        }
    }
}
