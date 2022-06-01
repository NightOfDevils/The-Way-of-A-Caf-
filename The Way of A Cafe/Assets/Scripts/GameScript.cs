using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameScript : MonoBehaviour
{
    public bool hasCoin = false;
    public bool hasHeart = false;
    public bool hasGem = false;

    public int step = 0;

    public Texture gamepanelTexture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ProgressStep()
    {
        step++;
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (step == 0)
        {
            if (other.gameObject.CompareTag("Coin"))
            {

                hasCoin = true;
                Destroy(other.gameObject);
                
            }

            if (hasCoin == true)
            {
                if (other.gameObject.CompareTag("Trent"))
                {

                    step++;
                    hasCoin = false;

                }
            }
        }

        if (step == 1)
        {
            if (other.gameObject.CompareTag("Heart"))
            {

                hasHeart = true;
                Destroy(other.gameObject);
                
            }

            if (hasHeart == true)
            {
                if (other.gameObject.CompareTag("Trent"))
                {

                    step++;
                    hasHeart = false;

                }
            }
        }

        if (step == 2)
        {
            if (other.gameObject.CompareTag("Gem"))
            {

                hasGem = true;
                Destroy(other.gameObject);

            }

            if (hasGem == true)
            {
                if (other.gameObject.CompareTag("Trent"))
                {

                    step++;
                    hasGem = false;

                }
            }
        }
    }
    */

    /*
    private void OnGUI()
    {

        GUIStyle gs = new GUIStyle();
        gs.richText = true;
        gs.wordWrap = true;
        gs.normal.textColor = Color.white;
        //Create Black Background for text
        Rect rect1 = new Rect(100, 100, gamepanelTexture.width + 50, 40);
        //Create panel image texture
        GUI.DrawTexture(rect1, gamepanelTexture);
        //Add Text into Black Background

        if (step == 0)
        { 
            if (hasCoin == false)
            {
                GUI.Label(rect1, "<size=30>" + " Pick Up The Coin " + "</size>", gs);
            }
            else if (hasCoin == true)
            {
                GUI.Label(rect1, "<size=30>" + " Give Coin to Trent " + "</size>", gs);
            }
        }

        if (step == 1)
        { 
            if (hasHeart == false)
            {
                GUI.Label(rect1, "<size=30>" + " Pick Up The Heart " + "</size>", gs);
            }
            else if (hasHeart == true)
            {
                GUI.Label(rect1, "<size=30>" + " Give Heart to Trent " + "</size>", gs);
            }
        }

        if (step == 2)
        { 
            if (hasGem == false)
            {
                GUI.Label(rect1, "<size=30>" + " Pick Up The Gem " + "</size>", gs);
            }
            else if (hasGem == true)
            {
                GUI.Label(rect1, "<size=30>" + " Give Gem to Trent " + "</size>", gs);
            }
        }

        if (step == 3)
        {
            {
                GUI.Label(rect1, "<size=30>" + " You Win! " + "</size>", gs);
            }
        }
    }
    */
}
