using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Drink")]
public class Drink : ScriptableObject
{
   public Sprite sprite;
   public String itemName;

   public SlotTag itemTag = SlotTag.Drink;
   public int itemTime;
}
