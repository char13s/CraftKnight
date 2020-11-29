using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WeaponInventory : MonoBehaviour {
    [SerializeField] private WeaponInventSlot[] invent = new WeaponInventSlot[24];
    private static WeaponInventory instance;
    private static WeaponInventSlot lastSelectedSlot;
    public static event UnityAction clearDisplay;
    public static WeaponInventSlot LastSelectedSlot { get => lastSelectedSlot; set => lastSelectedSlot = value; }
    public static WeaponInventory GetEquipmentInvent() => instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public void AddToInvent(WeaponData item) {
        if (SearchForSlot() != null) {
            SearchForSlot().SetItem(item);
            Debug.Log("Item added");
        }
        else {
            Debug.Log("Slot null");
        }
    }
    private WeaponInventSlot SearchForSlot() {
        foreach (WeaponInventSlot item in invent) {
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
