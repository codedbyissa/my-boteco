using System;
using UnityEngine;

public enum SlotTag {None, Drink, Ingredient, Meal}

[CreateAssetMenu(menuName = "Menu/Slot")]
public class ItemSlot : ScriptableObject
{
   public Sprite sprite;
   public String itemName;
   public SlotTag itemTag;
}
