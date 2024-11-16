using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;

    public static InventoryItem carriedItem;

    [SerializeField] InventorySlot[] inventorySlots;

    [SerializeField] InventorySlot[] equipmentSlots;

    [SerializeField] Transform draggablesTransform;

    [SerializeField] InventoryItem itemPrefab;

    [SerializeField] Item[] items;

    [SerializeField] Button giveItemBtn;

    private void Awake(){
        Singleton = this;
        giveItemBtn.onClick.AddListener(delegate { SpawnInventoryItem(); });
    }

    private void Update(){
        if(carriedItem == null){
            return;
        }

        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item){
        if(carriedItem != null){
            if(item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag){
                return;
            }

            item.activeSlot.SetItem(carriedItem);
        }

        if(item.activeSlot.myTag != SlotTag.None){
            EquipEquipment(item.activeSlot.myTag, null);
        }

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggablesTransform); 
    }

    public void EquipEquipment(SlotTag tag, InventoryItem item = null){
        switch(tag){
            case SlotTag.Drink:
                if(item == null){
                    Debug.Log("Removeu um item da tag Drink");
                } else {
                    Debug.Log("Equipou um item da tag Drink");
                }
                break;
            case  SlotTag.Ingredient:
                if(item == null){
                    Debug.Log("Removeu um item da tag Ingredient");
                } else {
                    Debug.Log("Equipou um item da tag Ingredient");
                }
                break;
            case  SlotTag.Meal:
                if(item == null){
                    Debug.Log("Removeu um item da tag Meal");
                } else {
                    Debug.Log("Equipou um item da tag Meal");
                }
                break;
        }
    }

    public void SpawnInventoryItem(Item item = null){
        Item _item = item;
        if(_item == null){
            _item = PickRadomItem();
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].myItem == null){
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    Item PickRadomItem(){
        int random = Random.Range(0, items.Length);
        return items[random];
    }    
}
