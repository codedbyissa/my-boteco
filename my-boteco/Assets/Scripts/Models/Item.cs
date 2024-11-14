using UnityEngine;

public enum SlotTag {None, Drink, Ingredient, Meal}

[CreateAssetMenu(menuName = "Menu/Item")]
public class Item : ScriptableObject
{
   public Sprite sprite;
   public SlotTag itemTag;
}
