using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftMaterialSlots : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text itemName;
    //[SerializeField] private WeaponStatsDisplay display;
    private CraftMaterialData item;
    private CraftMaterialInventory invent;
    private Button button;
    public CraftMaterialData Item { get => item; set => item = value; }

    public void SlotSelected() {
        CraftMaterialInventory.LastSelectedSlot = this;
    }
    public void SetToSlot() {
        if (item != null) {
            CraftMaterialInventory.LastSelectedSlot.SetItem(item);
        }
    }
    public void SetItem(CraftMaterialData data) {
        Item = data;
        image.sprite = data.Data.Sprite;

        itemName.text = data.Data.Name;
    }
    public void ClearSlot() {
        Item = null;
        image.sprite = null;
        itemName.text = "";
    }
    //public void OnHighLight() {
    //    if (item != null) { 
    //    display.AttackStat.text = "Attack Power: "+item.AttackPowah.ToString();
    //    display.Ability.text = item.Ability;
    //    display.Description.text = item.Data.Description;
    //    }
    //}
}
