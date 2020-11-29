using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CraftMaterialInventory : MonoBehaviour
{
    [SerializeField] private CraftMaterialSlots[] invent = new CraftMaterialSlots[24];
    private static CraftMaterialInventory instance;
    private static CraftMaterialSlots lastSelectedSlot;
    public static event UnityAction clearDisplay;
    public static CraftMaterialSlots LastSelectedSlot { get => lastSelectedSlot; set => lastSelectedSlot = value; }
    public static CraftMaterialInventory GetEquipmentInvent() => instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public void AddToInvent(CraftMaterialData item) {
        if (SearchForSlot() != null) {
            SearchForSlot().SetItem(item);
            Debug.Log("Item added");
        }
        else {
            Debug.Log("Slot null");
        }
    }
    private CraftMaterialSlots SearchForSlot() {
        foreach (CraftMaterialSlots item in invent) {
            if (item.Item == null) {
                return item;
            }
        }
        return null;
    }
    public void EmptyASlot() {
        lastSelectedSlot.ClearSlot();
        if (clearDisplay != null) {
            clearDisplay();
        }
    }
}
