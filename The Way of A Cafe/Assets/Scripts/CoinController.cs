using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CoinController : MonoBehaviour
{

    public bool hasCoin;
    public GameObject coin;

    public void PickUpCoin()
    {

        if(!hasCoin)
        {

            hasCoin = true;
            Debug.Log("Picked Up Coin");
            Destroy(coin);

        }

    }
}
