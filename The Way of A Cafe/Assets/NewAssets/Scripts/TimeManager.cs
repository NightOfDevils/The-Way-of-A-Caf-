using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI machineTimer1;
    public TextMeshProUGUI machineTimer2;
    public CraftingManager craft1;
    public CraftingManager craft2;

    private float timeStart;
    private int whichMachine;
    private bool timerOn = false;
    public void StartTimer(int num)
    {
        whichMachine = num;
        if(whichMachine == 1)
        {
            timeStart = craft1.ReturnMachine().machineTime;
            machineTimer1.SetText(timeStart.ToString());
            machineTimer1.gameObject.SetActive(true);
            timerOn = true;
        }
        else if(whichMachine == 2)
        {
            timeStart = craft2.ReturnMachine().machineTime;
            machineTimer2.SetText(timeStart.ToString());
            machineTimer2.gameObject.SetActive(true);
            timerOn = true;
        }
    }

    void Update()
    {
        if(whichMachine == 1)
        {
            if (timeStart < 0)
            {
                Debug.Log("We Hit 0!");
                craft1.SpawnProduct();
                timeStart = 50f;
                machineTimer1.gameObject.SetActive(false);
                timerOn = false;
            }
            else if (timerOn)
            {
                timeStart -= Time.deltaTime;
                machineTimer1.SetText(Mathf.Round(timeStart).ToString());
            }
        }
        else if(whichMachine == 2)
        {
            if (timeStart < 0)
            {
                Debug.Log("We Hit 0!");
                craft2.SpawnProduct();
                timeStart = 50f;
                machineTimer2.gameObject.SetActive(false);
                timerOn = false;
            }
            else if (timerOn)
            {
                timeStart -= Time.deltaTime;
                machineTimer2.SetText(Mathf.Round(timeStart).ToString());
            }
        }
    }
}
