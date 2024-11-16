using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{

    public InventoryItem myItem { get; set; }

    public SlotTag myTag;

    public void OnPointerClick(PointerEventData eventData){

        if(eventData.button == PointerEventData.InputButton.Left){
            if(Inventory.carriedItem == null)
            {
                return;
            }

            if(myTag != SlotTag.None && Inventory.carriedItem.myItem.itemTag != myTag)
            {
                return;
            }

            SetItem(Inventory.carriedItem);
        }

    }

    public void SetItem(InventoryItem item){
        Inventory.carriedItem = null;
        item.activeSlot.myItem = null;

        myItem = item;
        myItem.activeSlot = this;
        myItem.transform.SetParent(transform);
        myItem.canvasGroup.blocksRaycasts = true;

        if(myTag != SlotTag.None){
            Inventory.Singleton.EquipEquipment(myTag, myItem);
        }
    }
    
}
