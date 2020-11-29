using UnityEngine;
using UnityEngine.UI;
public class OreInventSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text itemName;
    //[SerializeField] private WeaponStatsDisplay display;
    private OreData item;
    private OreInventory invent;
    private Button button;
    public OreData Item { get => item; set => item = value; }

    public void SlotSelected() {
        OreInventory.LastSelectedSlot = this;
    }
    public void SetToSlot() {
        if (item != null) {
            OreInventory.LastSelectedSlot.SetItem(item);
        }
    }
    public void SetItem(OreData data) {
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
