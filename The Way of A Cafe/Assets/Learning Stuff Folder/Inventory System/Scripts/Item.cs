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
        EmptyCup,
        CoffeeBeans,
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
            case ItemType.EmptyCup: return ItemAssets.Instance.emptySprite;
            case ItemType.CoffeeBeans: return ItemAssets.Instance.beanSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Drink:
            case ItemType.EmptyCup:
            case ItemType.CoffeeBeans:
            //case ItemType.Food:
                return true;
            case ItemType.Food:
                return false;
        }
    }

}
