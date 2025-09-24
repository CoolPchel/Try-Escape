using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item; // чтобы программа поняла какая группа у придмета
    public int amount; //сколько дадут этот придмет при поднятии
    public bool isEmpty = true; //Пустой слот или нет
    public GameObject iconGO; //
    public TMP_Text itemAmountText; //если есть amount
    //public ClothType clothType = ClothType.None; - eсли есть одежда в игре 
    private void Awake()
    {
        iconGO = transform.GetChild(0).GetChild(0).gameObject; //Узнает детей обьекта
        itemAmountText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();

    }

    public void SetIcon(Sprite icon) //Меняет иконку каждому слоту
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }
}
