using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventSlots : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text itemName;
    [SerializeField] private WeaponStatsDisplay display;
    private ItemData item;
    private Inventory invent;
    private Button button;
    public ItemData Item { get => item; set => item = value; }

    // Start is called before the first frame update
    void Start(){
        image = GetComponent<Image>();
        itemName = GetComponent<Text>();
        button = GetComponent<Button>();
        
    }
    public void SlotSelected() {
        //Inventory.LastSelectedSlot = this;
    }
    public void SetToSlot() {
        if (item != null) { 
        //Inventory.LastSelectedSlot.SetItem(item);
        }
    }
    private void SetItem(ItemData data) {
        Item = data;
        image.sprite = data.Sprite;
        itemName.text = data.Name;
    }
    public void ClearSlot() {
        Item = null;
        image.sprite = null;
        itemName.text = "";
    }
    public void OnHighLight() {
        
    }
}
