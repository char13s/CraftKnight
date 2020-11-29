using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotionInventSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text itemName;
    //[SerializeField] private WeaponStatsDisplay display;
    private PotionData item;
    private PotionInventory invent;
    private Button button;
    public PotionData Item { get => item; set => item = value; }

    public void SlotSelected() {
        PotionInventory.LastSelectedSlot = this;
    }
    public void SetToSlot() {
        if (item != null) {
            PotionInventory.LastSelectedSlot.SetItem(item);
        }
    }
    public void SetItem(PotionData data) {
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
