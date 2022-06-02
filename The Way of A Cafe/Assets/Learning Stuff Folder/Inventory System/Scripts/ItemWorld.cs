using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) //Funcion that spawns items into the world
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemworld = SpawnItemWorld(dropPosition + randomDir * 1.5f, item);
        itemworld.GetComponent<Rigidbody2D>().AddForce(randomDir * 1.5f, ForceMode2D.Force);
        return itemworld;
    }


    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Gets the render image of the current item
        textMeshPro = transform.Find("text").GetComponent<TextMeshPro>(); // Gets the text for the current item
    }


    public void SetItem(Item item) // Sets the current item
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if(item.amount > 1) // If amount is greater than 1 set the text to display
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else // if not do not show text
        {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem() // Returns the current item
    {
        return item;
    }

    public void DestorySelf() // Destroys the current item
    {
        Destroy(gameObject);
    }

}
