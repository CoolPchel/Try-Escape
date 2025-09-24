using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Делаем так чтобы можно было создать эту подгруппу
[CreateAssetMenu(fileName = "Item",menuName = "Inventory/Items/New Item")]
//Пишим название скрипта так как написали название подгруппы
public class ItemCriat : ItemScriptableObject
{
    private void Start()
    {
        itemType = ItemType.BuffEffect;
    }
}
