using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
/// IPointerDownHandler - Следит за нажатиями мышки по объекту на котором висит этот скрипт
/// IPointerUpHandler - Следит за отпусканием мышки по объекту на котором висит этот скрипт
/// IDragHandler - Следит за тем не водим ли мы нажатую мышку по объекту
public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject audioInventar;
    public InventorySlot oldSlot;
    private Transform player;
    private QuickslotInventory quickslotInventory;
    public Transform savingEnvironment;

    public InfoObjact infoObjact;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ

    private void Start()
    {
        infoObjact = FindObjectOfType<InfoObjact>();//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        quickslotInventory = FindObjectOfType<QuickslotInventory>();
        //ПОСТАВЬТЕ ТЭГ "PLAYER" НА ОБЪЕКТЕ ПЕРСОНАЖА!
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioInventar = GameObject.FindGameObjectWithTag("AudioInventar");
        // Находим скрипт InventorySlot в слоте в иерархии
        oldSlot = transform.GetComponentInParent<InventorySlot>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Если слот пустой, то мы не выполняем то что ниже return;
        if (oldSlot.isEmpty)
            return;
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        //Делаем картинку прозрачнее
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        // Делаем так чтобы нажатия мышкой не игнорировали эту картинку
        GetComponentInChildren<Image>().raycastTarget = false;
        // Делаем наш DraggableObject ребенком InventoryPanel чтобы DraggableObject был над другими слотами инвенторя
        transform.SetParent(transform.parent.parent);
        if (oldSlot.item.itemName == "MainKnob")
        {
            audioInventar.GetComponent<AudioInventar>().isBMetalUiUp = true;
            infoObjact.knob = true;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
        if (oldSlot.item.itemName == "Fonarik")
        {
            audioInventar.GetComponent<AudioInventar>().isFonarikUiUp = true;
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = true;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
        if (oldSlot.item.itemName == "Energy")
        {
            audioInventar.GetComponent<AudioInventar>().isCanUiUp = true;
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = true;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
        if (oldSlot.item.itemName == "KeyGreen")
        {
            audioInventar.GetComponent<AudioInventar>().isKeyUiUp = true;
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = true;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
        if (oldSlot.item.itemName == "KeyRed")
        {
            audioInventar.GetComponent<AudioInventar>().isKeyUiUp = true;
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = true;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
        if (oldSlot.item.itemName == "KeyOrange")
        {
            audioInventar.GetComponent<AudioInventar>().isKeyUiUp = true;
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = true;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        // Делаем картинку опять не прозрачной
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        // И чтобы мышка опять могла ее засечь
        GetComponentInChildren<Image>().raycastTarget = true;

        //Поставить DraggableObject обратно в свой старый слот
        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        //Если мышка отпущена над объектом по имени UIBG, то...
        if (eventData.pointerCurrentRaycast.gameObject.name == "UIBG") // renamed to UIBG
        {
            // Выброс объектов из инвентаря - Спавним префаб обекта перед персонажем
            GameObject itemObject = Instantiate(oldSlot.item.itemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
            itemObject.transform.SetParent(savingEnvironment);
            // Устанавливаем количество объектов такое какое было в слоте
            itemObject.GetComponent<Item>().amount = oldSlot.amount;
            // убираем значения InventorySlot
            NullifySlotData();
            quickslotInventory.CheckItemImHand();
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ

        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent == null)
        {
            return;
        }
        else if(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
        {
            //Перемещаем данные из одного слота в другой
            if (oldSlot.item.itemName == "Fonarik")
            {
                audioInventar.GetComponent<AudioInventar>().isFonarikUiDown = true;
            }
            if (oldSlot.item.itemName == "Energy")
            {
                audioInventar.GetComponent<AudioInventar>().isCanUiDown = true;
            }
            //БольшиеПРедметы
            if (oldSlot.item.itemName == "MainKnob")
            {
                audioInventar.GetComponent<AudioInventar>().isBMetalUiDown = true;
            }
            //Ключи
            if (oldSlot.item.itemName == "KeyGreen" || oldSlot.item.itemName == "KeyRed" || oldSlot.item.itemName == "KeyOrange")
            {
                audioInventar.GetComponent<AudioInventar>().isKeyUiDown = true;
            }
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
            quickslotInventory.CheckItemImHand();
            infoObjact.knob = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.fonarik = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.greenKey = false; //нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.redKey = false; //нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.energyItem = false; //нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
            infoObjact.orangeKey = false;//нЕ ОБРАЩАЙТЕ ВНИМАНИЕ, ПРОСТО НЕОПЫТНОСТЬ
        }
       
    }
    public void NullifySlotData()
    {
        // убираем значения InventorySlot
        oldSlot.item = null;
        oldSlot.amount = 0;
        oldSlot.isEmpty = true;
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        oldSlot.iconGO.GetComponent<Image>().sprite = null;
        oldSlot.itemAmountText.text = "";
    }

    void ExchangeSlotData(InventorySlot newSlot)
    {
        // Временно храним данные newSlot в отдельных переменных
        ItemScriptableObject item = newSlot.item;
        int amount = newSlot.amount;
        bool isEmpty = newSlot.isEmpty;
        GameObject iconGO = newSlot.iconGO;
        TMP_Text itemAmountText = newSlot.itemAmountText;

        // Заменяем значения newSlot на значения oldSlot
        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;
        if (oldSlot.isEmpty == false)
        {
            newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);
            if (oldSlot.item.maximumAmount != 1) // если придмет не стакаеться
            {
                newSlot.itemAmountText.text = oldSlot.amount.ToString();
            }
            else
            {
                newSlot.itemAmountText.text = "";
            }
        }
        else
        {
            newSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            newSlot.iconGO.GetComponent<Image>().sprite = null;
            newSlot.itemAmountText.text = "";
        }
        
        newSlot.isEmpty = oldSlot.isEmpty;

        // Заменяем значения oldSlot на значения newSlot сохраненные в переменных
        oldSlot.item = item;
        oldSlot.amount = amount;
        if (isEmpty == false)
        {
            oldSlot.SetIcon(item.icon);
            if (item.maximumAmount != 1) // если придмет не стакаеться
            {
                oldSlot.itemAmountText.text = amount.ToString();
            }
            else
            {
                newSlot.itemAmountText.text = "";
            }
            
        }
        else
        {
            oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            oldSlot.iconGO.GetComponent<Image>().sprite = null;
            oldSlot.itemAmountText.text = "";
        }
        
        oldSlot.isEmpty = isEmpty;
    }
}