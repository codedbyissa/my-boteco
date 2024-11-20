using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Meal")]
public class Meal : ScriptableObject, IOrderItem
{   
    public int id;
    public string itemName;
    public SlotTag itemTag = SlotTag.Meal;
    public int itemTime;
    public Sprite sprite;

    public int Id => id;
    public string ItemName => itemName;
    public int ItemTime => itemTime;
    public Sprite Sprite => sprite;
}
