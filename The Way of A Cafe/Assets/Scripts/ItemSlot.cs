using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    /*
    private Vector2 currentPos;
    public int slotNumber = 0;

    private float x = 0f;
    private float y = 0f;

    private float x2 = 0f;
    private float y2 = 0f;

    private float newX, newY;

    */
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            /*
            currentPos = GetComponent<RectTransform>().anchoredPosition;
            x = currentPos.x; 
            y = currentPos.y;
            x2 = currentPos.x;
            y2 = currentPos.y;

            if(x < 0)
            {
                x2 *= -1f;
                y2 *= -1f;
            }

            newX = x + x2;
            newY = y + y2;

            if (newY == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == slotNumber)
                    {
                        newX += (100 * i);
                    }
                }
            }
            if(newX == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == slotNumber)
                    {
                        newY += (100 * i);
                    }
                }
            }
                

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, newY);
            */
        }
    }
}
