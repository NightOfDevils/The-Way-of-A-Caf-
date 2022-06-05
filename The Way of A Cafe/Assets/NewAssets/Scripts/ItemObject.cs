using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Item Object")]
public class ItemObject : ScriptableObject
{
    public new string name;
    public string craftingRecipe;
    public Sprite icon;
    public int amount;

}
