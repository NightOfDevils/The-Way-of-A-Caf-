using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{

    private CraftItem currentItem;
    public Image customCursor;

    public void OnMouseDownItem(CraftItem item)
    {

        if(currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }

    }
}
