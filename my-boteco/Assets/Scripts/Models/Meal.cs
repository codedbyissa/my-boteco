using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Meal")]
public class Meal : ScriptableObject
{
   public Sprite sprite;
   public String itemName;

   public SlotTag itemTag = SlotTag.Meal;
   public int itemTime;
}
