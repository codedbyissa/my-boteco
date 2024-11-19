using UnityEngine;
using UnityEngine.UI;

public class SlotHolder : MonoBehaviour
{
    public ItemSlot slot;

    public void EquipItem(ItemSlot item)
    {
        if (item == null) return;

        slot = item;
        var slotImage = transform.Find("Sprite")?.GetComponent<Image>();
        slotImage.sprite = slot.sprite;
        slotImage.enabled = true; 
        Debug.Log("Equipou o Drink " + item.itemName);
    }

    public void ClearSlot()
    {
        slot = null;
        var slotImage = transform.Find("Sprite")?.GetComponent<Image>();
        slotImage.sprite = null;
        slotImage.enabled = false; 
    }
}

