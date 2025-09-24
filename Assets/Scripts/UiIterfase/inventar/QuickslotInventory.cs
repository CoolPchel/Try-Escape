using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickslotInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    public GameObject player;
    public GameObject audioItems;
    public Transform quickslotParent;
    public InventoryManager inventoryManager;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public Text healthText;
    public InventorySlot activeSlot = null; // для того чтобы определить какую анимацию запускать для предмета
    public Transform hend; //Рука
    //Двери с ключами
    private GameObject doorGreen;
    private GameObject doorRed;
    private GameObject doorOrange;
    public bool keyCanUse;
    public bool colorGreen;
    public bool colorRed;
    public bool colorOrange;
    //Фонарик
    public GameObject light;
    private bool on = false;
    public FlashLight fonarik;
    public GameObject indicator;
    //Сётчик
    private GameObject mainSwitch;
    public bool knobCanUse;

    public MenuePause menuePause;

    public InfoTask taskComplit;

    void Start()
    {
        mainSwitch = GameObject.FindGameObjectWithTag("Switch");
        doorGreen = GameObject.FindGameObjectWithTag("DoorGreen");
        doorRed = GameObject.FindGameObjectWithTag("DoorRed");
        doorOrange = GameObject.FindGameObjectWithTag("DoorOrange");
    }
    // Update is called once per frame
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw > 0.1 && !menuePause.pauseGame)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentQuickslotID >= quickslotParent.childCount-1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // Прибавляем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }

            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            activeSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
            ShowItemInHand();
            // Здесь добавляем что случиться когда мы ВЫДЕЛЯЕМ слот (ВКЛ нужный нам предмет, поменять аниматор ...)

        }
        if (mw < -0.1 && !menuePause.pauseGame)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount-1;
            }
            else
            {
                // Уменьшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            activeSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
            ShowItemInHand();
            // Здесь добавляем что случиться когда мы ВЫДЕЛЯЕМ слот (ВКЛ нужный нам предмет, поменять аниматор ...)
            
        }
        if (!menuePause.pauseGame)
        {
            // Используем цифры
            for(int i = 0; i < quickslotParent.childCount; i++)
            {
                // если мы нажимаем на клавиши 1 по 5 то...
                if (Input.GetKeyDown((i + 1).ToString())) {
                    // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
                    if (currentQuickslotID == i)
                    {
                        // Ставим картинку "selected" на слот если он "not selected" или наоборот
                        if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                        {
                            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                            activeSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>(); 
                            ShowItemInHand();
                            //foreach...
                        }
                        else
                        {
                            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                            activeSlot = null;
                            HideItemInHand();
                            //foreach...  
                        }
                    }
                    // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                        currentQuickslotID = i;

                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                        activeSlot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
                        ShowItemInHand();
                    }
                }
            }
        }
        
        // Используем предмет по нажатию на левую кнопку мыши
        if (Input.GetMouseButtonDown(1))
        {
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item != null) //проверка есть ли обьект в слоте
            {

                if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.isBuff && !inventoryManager.isOpened && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)// проверка 1)это бафф или нет 2)когда открыт ивентарь 3)выделена ли ячейка, то 
                {
                    // Даёт бафф
                    ChangeCharacteristics();

                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount <= 1) //если кол меньше 1, то ячейка становиться пустой
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                    }
                    else //иначе просто -1 шт предмета
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount--;
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount.ToString();
                    }
                }

                if (!quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.isBuff && !inventoryManager.isOpened && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)// проверка 1)это бафф или нет 2)когда открыт ивентарь 3)выделена ли ячейка, то 
                {
                    UseFonarik();
                    if (knobCanUse)
                    {
                        UseKnobItem();
                    }
                }

                if (keyCanUse && !inventoryManager.isOpened && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)// проверка 1)это бафф или нет 2)когда открыт ивентарь 3)выделена ли ячейка, то 
                {
                    if (colorGreen)
                    {
                        UsekeyGreenItem();
                    }
                    if (colorRed)
                    {
                        UsekeyRedItem();
                    }
                    if (colorOrange)
                    {
                        UsekeyOrangeItem();
                    }
                }
            }
        }
    }
    public void CheckItemImHand() //проверка ячейки пустая она или нет
    {
        if (activeSlot != null) //показываем предмет
        {
            ShowItemInHand();
        }
        else //убираем предмет
        {
            HideItemInHand();
        }
    }

    private void UsekeyGreenItem()
    {
        if (activeSlot.item.inHandName == "KeyHGreen")
        {
            taskComplit.proverca = true;
            taskComplit.nameComplitTask = "Зелёная дверь";
            doorGreen.GetComponent<Doors>().loked = false;
            hend.GetChild(0).gameObject.SetActive(false);
            audioItems.GetComponent<AudioItems>().isKey = true;
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount <= 1) //если кол меньше 2, то ячейка становиться пустой
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
            }
            else //иначе просто -1 шт предмета
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount--;
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount.ToString();
            }
        }
    }
    private void UsekeyRedItem()
    {
        if (activeSlot.item.inHandName == "KeyHRed")
        {
            taskComplit.proverca = true;
            taskComplit.nameComplitTask = "Красная дверь";
            doorRed.GetComponent<Doors>().loked = false;
            hend.GetChild(1).gameObject.SetActive(false);
            audioItems.GetComponent<AudioItems>().isKey = true;
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount <= 1) //если кол меньше 2, то ячейка становиться пустой
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
            }
            else //иначе просто -1 шт предмета
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount--;
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount.ToString();
            }
        }
    }
    private void UsekeyOrangeItem()
    {
        if (activeSlot.item.inHandName == "KeyHOrange")
        {
            taskComplit.proverca = true;
            taskComplit.nameComplitTask = "Оранжевая дверь";
            doorOrange.GetComponent<Doors>().loked = false;
            hend.GetChild(2).gameObject.SetActive(false);
            audioItems.GetComponent<AudioItems>().isKey = true;
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount <= 1) //если кол меньше 2, то ячейка становиться пустой
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
            }
            else //иначе просто -1 шт предмета
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount--;
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount.ToString();
            }
        }
    }
    private void UseFonarik()
    {
        if (activeSlot.item.inHandName == "FonarikH")
        {
            audioItems.GetComponent<AudioItems>().isFonarik = true;
            if (!fonarik.nullPuver)
            {
                on = !on;
                if (on)
                {
                    light.SetActive(true);
                    fonarik.isWork = true;
                }
                else
                {
                    light.SetActive(false);
                    fonarik.isWork = false;
                }
            }
            
        }
    }
    private void UseKnobItem()
    {
        if (activeSlot.item.inHandName == "KnobH")
        {
            mainSwitch.GetComponent<Sechik>().haveKnob = true;
            audioItems.GetComponent<AudioItems>().isBMetal = true;
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount <= 1) //если кол меньше 2, то ячейка становиться пустой
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
            }
            else //иначе просто -1 шт предмета
            {
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount--;
                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount.ToString();
            }
        }
        
    }

    private void ChangeCharacteristics()
    {
        player.GetComponent<FirstPersonMovement>().getBuff = true;
        audioItems.GetComponent<AudioItems>().isCan = true;
    }

    private void ShowItemInHand()
    {
        HideItemInHand();
        if (activeSlot.item == null)
        {
            return;
        }
        for(int i = 0; i<hend.childCount; i++)
        {
            if (activeSlot.item.inHandName == hend.GetChild(i).name)
            {
                hend.GetChild(i).gameObject.SetActive(true);
                if (hend.GetChild(i).name == "FonarikH")
                {
                    indicator.SetActive(true);
                }
            }
        }
    }

    private void HideItemInHand()
    {
        for(int i = 0; i<hend.childCount; i++)
        {
            if (hend.GetChild(i).name == "FonarikH")
            {
                on = false;
                light.SetActive(false);
                fonarik.isWork = false;
                indicator.SetActive(false);
            }
            hend.GetChild(i).gameObject.SetActive(false);
        }
    }
}
