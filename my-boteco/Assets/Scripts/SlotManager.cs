using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public ItemSlot slot;

    public void EquipItem(ItemSlot item)
    {
        if (item == null) return;

        slot = item;
        var slotImage = transform.Find("Sprite")?.GetComponent<Image>();
        slotImage.sprite = slot.sprite;
        slotImage.enabled = true; 
    }

    public void ClearSlot()
    {
        slot = null;
        var slotImage = transform.Find("Sprite")?.GetComponent<Image>();
        slotImage.sprite = null;
        slotImage.enabled = false; 
    }
}

