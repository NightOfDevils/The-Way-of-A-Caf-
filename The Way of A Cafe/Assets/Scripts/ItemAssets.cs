using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;
    public Transform ItemWorldSpawner_Drink;
    public Transform ItemWorldSpawner_Food;
    public Transform ItemWorldSpawner_Empty;
    public Transform ItemWorldSpawner_Bean;

    public Sprite drinkSprite;
    public Sprite foodSprite;
    public Sprite emptySprite;
    public Sprite beanSprite;
}
