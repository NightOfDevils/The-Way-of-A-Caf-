using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Food,
        Drink,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Drink: return ItemAssets.Instance.drinkSprite;
            case ItemType.Food: return ItemAssets.Instance.foodSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Drink:
                return true;
            case ItemType.Food:
                return false;
        }
    }

}
