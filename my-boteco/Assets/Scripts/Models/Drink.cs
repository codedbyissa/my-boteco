using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Drink")]
public class Drink : ScriptableObject, IOrderItem
{
    public int id;
    public string itemName;
    public SlotTag itemTag = SlotTag.Drink;
    public int itemTime;
    public Sprite sprite;

    public int Id => id;
    public string ItemName => itemName;
    public int ItemTime => itemTime;
    public Sprite Sprite => sprite;

}
