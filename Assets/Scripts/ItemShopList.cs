using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CreatItemShop",fileName ="ItemShop")]
public class ItemShopList:ScriptableObject
{

    public Sprite itemSprite;

    public string itemName;   

    public int minPrice;

    public int maxPrice;

    public int idItem;

   
}
