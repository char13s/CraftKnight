using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMaterial : MonoBehaviour
{
    [SerializeField] private CraftMaterialData craftData = new CraftMaterialData();
    private CraftMaterialInventory invent;
    private ItemManager itemStorage;
    public CraftMaterialData CraftData { get => craftData; set => craftData = value; }

    private void Start() {
        invent = CraftMaterialInventory.GetEquipmentInvent();
        itemStorage = ItemManager.GetItemManager();
    }
    public void PickUp() {
        ItemData item=itemStorage.GetItem(craftData.Data.Id);
       if (item.Quantity > 0) {
           item.Quantity++;
       }
       else {
            item.Quantity++;
            invent.AddToInvent(CraftData);
        }
        Destroy(gameObject);
    }
}
