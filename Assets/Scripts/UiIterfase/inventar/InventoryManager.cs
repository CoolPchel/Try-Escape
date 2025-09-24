using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот скрипт нужен для того чтобы игра знала сколько и где слоты

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG; //Сам инвентарь
    public Transform inventoryPanel; //Сам инвентарь с ячейками
    public Transform quickslotPanel;
    public List<InventorySlot> slots = new List<InventorySlot>(); //Слоты у инвентаря (InventorySlot - название скрипта)
    public bool isOpened; //Кнопка для проверки открыт ли инвентарь
    public Camera mainCamera;
    public float reachDistance = 3f;
    public GameObject currentWeapon;
    public FirstPersonLook firstPersonLook;
    private bool canPickUp = false;
    private bool oneShot;
    [SerializeField] private Transform player;

    public MenuePause menuePause;

    public FlashLight fl;

    public GameObject audioInven;
    [SerializeField] AudioClip openBackpack;
    [SerializeField] AudioClip clouseBackpack;

    //[SerializeField] private List<ClothAdder> _clothAdders = new List<ClothAdder>();

    private void Awake()
    {
        UIBG.SetActive(true);
    }

    void Start()
    {
        //Цыкл добовляет сам слоты
        for(int i = 0; i < inventoryPanel.childCount; i++) //childCount - пишим тогда когда у обьекта есть дети и мы обращаеся к ним
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        for(int i = 0; i < quickslotPanel.childCount; i++) //childCount - пишим тогда когда у обьекта есть дети и мы обращаеся к ним
        {
            if(quickslotPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(quickslotPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIBG.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
    }
 
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !menuePause.pauseGame) // Закрытие и открытие инвентаря
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                audioInven.GetComponent<AudioSource>().clip = openBackpack;
                firstPersonLook.sensitivity = 0;
                UIBG.SetActive(true);
                inventoryPanel.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                oneShot = true;
            }
            if (!isOpened && oneShot)
            {
                audioInven.GetComponent<AudioSource>().clip = clouseBackpack;
                firstPersonLook.sensitivity = 2;
                UIBG.SetActive(false);
                inventoryPanel.gameObject.SetActive(false);
                //Убираем курсор и делаем его невидимым
                Cursor.lockState = CursorLockMode.Locked;
                oneShot = false;

            }
            audioInven.GetComponent<AudioInventar>().playSoundInventar = true;
        }
        if (Input.GetMouseButtonDown(0)) PickUp();
    }
    public void AddItemToSlot(ItemScriptableObject _item, int _amount, int slotId)
    {
        InventorySlot slot = slots[slotId];
        slot.item = _item;
        slot.isEmpty = false;
        slot.SetIcon(_item.icon);
        
        if (_amount <= _item.maximumAmount)
        {
            slot.amount = _amount;
            if (slot.item.maximumAmount != 1)
            {
                slot.itemAmountText.text = slot.amount.ToString();
            }
        }
        else
        {
            slot.amount = _item.maximumAmount;
            _amount -= _item.maximumAmount;
            if (slot.item.maximumAmount != 1)
            {
                slot.itemAmountText.text = slot.amount.ToString();
            }
        }
        //ЕСЛИ ЕСТЬ ОДЕЖДА В ИГРЕ
        //if (slot.clothType != ClothType.None && !slot.isEmpty)
        //{
            //foreach (ClothAdder clothAdder in _clothAdders)
            //{
                //clothAdder.addClothes(slot.item.clothingPrefab);
            //}
        //}
    }

    public void RemoveItemFromSlot(int slotId)
    {
        InventorySlot slot = slots[slotId];
        //ЕСЛИ ЕСТЬ ОДЕЖДА В ИГРЕ
        //if (slot.clothType != ClothType.None && !slot.isEmpty)
        //{
            //foreach (ClothAdder clothAdder in _clothAdders)
            //{
                //clothAdder.addClothes(slot.item.clothingPrefab);
            //}
        //}
        slot.item = null;
        slot.isEmpty = true;
        slot.amount = 0;
        //slot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        //slot.iconGO.GetComponent<Image>().sprite = null;
        slot.itemAmountText.text = "";
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        //Если инвентарь заполнен, то подобраный предмет выкинеться
        bool allFull = true;
        foreach(InventorySlot inventorySlot in slots)
        {
            if (inventorySlot.isEmpty)
            {
                allFull = false;
                break;
            }
        }
        if (allFull)
        {
            GameObject itemObject = Instantiate(_item.itemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
            itemObject.GetComponent<Item>().amount = _amount;
        }
        //стакаем предметы вместе
        int amount = _amount;
        foreach (InventorySlot slot in slots) //Старт цикла
        {
            //В слоте уже имеется этот предмет
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount) //проверка сколько кол может стакаться в один придмет
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString(); //если есть _amount
                    return;
                }
                continue;
            }
        }
        // добавляем предметы в свободные ячейки
        foreach (InventorySlot slot in slots)
        {
            if (amount <= 0)
                return;
            if (slot.isEmpty == true) //Добовляет в инвентарь предмет
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                if (slot.item.maximumAmount != 1) //если придмет не стакаеться
                {
                    slot.itemAmountText.text = _amount.ToString();
                }
                break; //Окончание цикла
            }
        }
        
    }
    private void PickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, reachDistance))
        {
            if(hit.transform.tag == "ItemCan")
            {
                if(hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    currentWeapon.GetComponent<PickUpItems>().oudioCan = true;
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }

            if(hit.transform.tag == "ItemFonarik")
            {
                if(hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    currentWeapon.GetComponent<PickUpItems>().oudioFonarik = true;
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }

            if(hit.transform.tag == "ItemKey")
            {
                if(hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    currentWeapon.GetComponent<PickUpItems>().oudioKey = true;
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }

            if(hit.transform.tag == "ItemBigMetal")
            {
                if(hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    currentWeapon.GetComponent<PickUpItems>().oudioBMetal = true;
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }

            if(hit.transform.tag == "ItemButtory")
            {
                if(hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    currentWeapon.GetComponent<PickUpItems>().oudioLMettal = true;
                    //PlayerPrefs.SetString("Inventory", "Buttory");
                    fl.col++;
                    Destroy(hit.collider.gameObject);
                }
            }
            
        }
    }
}

