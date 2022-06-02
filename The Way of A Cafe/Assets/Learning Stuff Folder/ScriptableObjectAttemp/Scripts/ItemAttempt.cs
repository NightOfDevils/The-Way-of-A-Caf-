using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Item")]
public class ItemAttempt : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite art;
    public int amount;
}
