using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OreInventory : MonoBehaviour
{
    [SerializeField] private OreInventSlot[] invent = new OreInventSlot[24];
    private static OreInventory instance;
    private static OreInventSlot lastSelectedSlot;
    public static event UnityAction clearDisplay;
    public static OreInventSlot LastSelectedSlot { get => lastSelectedSlot; set => lastSelectedSlot = value; }
    public static OreInventory GetEquipmentInvent() => instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public void AddToInvent(OreData item) {
        if (SearchForSlot() != null) {
            SearchForSlot().SetItem(item);
            Debug.Log("Item added");
        }
        else {
            Debug.Log("Slot null");
        }
    }
    private OreInventSlot SearchForSlot() {
        foreach (OreInventSlot item in invent) {
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
