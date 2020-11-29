using UnityEngine;
using UnityEngine.UI;

public class WeaponInventSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text itemName;
    [SerializeField] private WeaponStatsDisplay display;
    private WeaponData item;
    private WeaponInventory invent;
    private Button button;


    public WeaponData Item { get => item; set => item = value; }

    public void SlotSelected() {
        WeaponInventory.LastSelectedSlot = this;
    }
    public void SetToSlot() {
        if (item != null) {
            WeaponInventory.LastSelectedSlot.SetItem(item);
        }
    }
    public void SetItem(WeaponData data) {
        Item = data;
        image.sprite = data.Data.Sprite;
        
        itemName.text = data.Data.Name;
    }
    public void ClearSlot() {
        Item = null;
        image.sprite = null;
        itemName.text = "";
    }
    public void OnHighLight() {
        if (item != null) { 
        display.AttackStat.text = "Attack Power: "+item.AttackPowah.ToString();
        display.Ability.text = item.Ability;
        display.Description.text = item.Data.Description;
        }
    }
}
