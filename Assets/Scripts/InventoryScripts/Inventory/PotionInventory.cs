using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PotionInventory : MonoBehaviour
{
    [SerializeField] private PotionInventSlot[] invent = new PotionInventSlot[24];
    private static PotionInventory instance;
    private static PotionInventSlot lastSelectedSlot;
    public static event UnityAction clearDisplay;
    public static PotionInventSlot LastSelectedSlot { get => lastSelectedSlot; set => lastSelectedSlot = value; }
    public static PotionInventory GetEquipmentInvent() => instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public void AddToInvent(PotionData item) {
        if (SearchForSlot() != null) {
            SearchForSlot().SetItem(item);
            Debug.Log("Item added");
        }
        else {
            Debug.Log("Slot null");
        }
    }
    private PotionInventSlot SearchForSlot() {
        foreach (PotionInventSlot item in invent) {
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
