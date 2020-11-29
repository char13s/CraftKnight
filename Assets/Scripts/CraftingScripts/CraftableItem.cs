using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftableItem : MonoBehaviour
{
    [SerializeField] private CraftSlot slot1;
    [SerializeField] private CraftSlot slot2;
    [SerializeField] private CraftSlot slot3;

    [SerializeField] private Weapon weapon;
    private WeaponInventory invent;

    public Weapon Weapon { get => weapon; set => weapon = value; }
    public CraftSlot Slot1 { get => slot1; set => slot1 = value; }
    public CraftSlot Slot2 { get => slot2; set => slot2 = value; }
    public CraftSlot Slot3 { get => slot3; set => slot3 = value; }

    [SerializeField] private CraftDisplay display;
    
    void Start()
    {
        invent = WeaponInventory.GetEquipmentInvent();
    }
    public void CreateItem() {
        if (Slot1.CheckQuantity()&&Slot2.CheckQuantity()&&Slot3.CheckQuantity()) {
            invent.AddToInvent(Weapon.Data);
        }
    }
    public void OnHighLight() {
        display.Item = this;
    }
}
