using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftingManager : MonoBehaviour
{

    public ClickDrag clickDrag;
    public Slot[] craftingSlots; // array of crafting slots
    public List<ItemObject> itemList; // list of items
    public ItemObject[] recipes; // array of recipes
    public ItemObject[] recipeResults; // item array of product items 
    public Slot resultSlot; // slot for final product
    public bool subItems = false;
    public MachineObject machineObject;
    [SerializeField] Timer timer;
    private int productID;

    private void Update()
    {

        foreach (Slot slot in craftingSlots)
            {
                RectTransform slotTransform = slot.GetComponent<RectTransform>();
                RectTransform assetTransform = slotTransform.Find("Assets").GetComponent<RectTransform>();
            TextMeshProUGUI itemText = assetTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                if (slot.itemAmount == 0)
                {
                    slot.item = null;
                    itemList[slot.index] = null;
                    Image image = assetTransform.Find("Icon").GetComponent<Image>();
                    image.sprite = null;
                    assetTransform.gameObject.SetActive(false);
                }
                else
                {
                    if (slot.itemAmount == 1)
                    {
                        itemText.SetText("");
                    }
                    else
                    {
                        itemText.SetText(slot.itemAmount.ToString());
                    }
                }
            }

        if (Input.GetMouseButtonUp(0))
        {
            if (clickDrag.WhichSlots() == "CraftingSlot")
            {
                itemList[clickDrag.GetIndex()] = clickDrag.GetItem(); 
            }
            foreach (Slot slot in craftingSlots)
            {
                RectTransform slotTransform = slot.GetComponent<RectTransform>();
                RectTransform assetTransform = slotTransform.Find("Assets").GetComponent<RectTransform>();
                TextMeshProUGUI itemText = assetTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                if (slot.item == null)
                {
                    itemList[slot.index] = null;
                }
                else if(slot.item != null)
                {
                    if(slot.itemAmount == 1)
                    {
                        itemText.SetText("");
                    }
                    else
                    {
                        itemText.SetText(slot.itemAmount.ToString());
                    }
                    itemList[slot.index] = slot.item;
                }
            }
        }
    }

    public void OnMouseDownButton()
    {
        CheckForCreateRecipes();
    }

    public void SubItems(int sub)
    {
        foreach (Slot slot in craftingSlots)
        {
            slot.itemAmount -= sub;
        }
    }

    public void SpawnProduct()
    {
        RectTransform slotTransform = resultSlot.GetComponent<RectTransform>();
        resultSlot.gameObject.SetActive(true); // set result slot to visible
        resultSlot.itemAmount = 1;
        Image image = slotTransform.Find("Icon").GetComponent<Image>();
        image.sprite = recipeResults[productID].icon; // set the sprite in result slot to the sprite of the product
        TextMeshProUGUI itemText = slotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
        itemText.SetText("");
        resultSlot.item = recipeResults[productID]; // set the item in the result slot to the product item
    }

    void CheckForCreateRecipes() // checking if any recipes were made
    {
        resultSlot.gameObject.SetActive(false); // set result slot to invisible
        resultSlot.item = null; // delete any item from null slot

        string currentRecipeString = ""; // create a string to hold the current item recipe
        foreach(ItemObject item in itemList) // check every item in the item list
        {
            if(item != null) // if item(s) exists within the list
            {
                currentRecipeString += item.name; // add the item name to the current recipe string
            }
            else // if no item in slot
            {
                currentRecipeString += "null"; // add null to the recipe in case of empty space needed
            }
        }

        for(int i = 0; i < recipes.Length; i++) //for loop that checks if the current recipe matches any premade recipes
        {
            if(recipes[i].craftingRecipe == currentRecipeString) // if recipe matches current recipe
            {
                productID = i;
                timer.gameObject.SetActive(true);
                timer.setDuration(machineObject.machineTime).Begin();
                SubItems(1);
                /*
                if (timer.IsFinished()) //FIX TIMER NOT WORKING PROPERLY
                {
                    RectTransform slotTransform = resultSlot.GetComponent<RectTransform>();
                    resultSlot.gameObject.SetActive(true); // set result slot to visible
                    resultSlot.itemAmount = 1;
                    Image image = slotTransform.Find("Icon").GetComponent<Image>();
                    image.sprite = recipeResults[i].icon; // set the sprite in result slot to the sprite of the product
                    TextMeshProUGUI itemText = slotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                    itemText.SetText("");
                    resultSlot.item = recipeResults[i]; // set the item in the result slot to the product item
                }
                */
            }
        }
    }
}
