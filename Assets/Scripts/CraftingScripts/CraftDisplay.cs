using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftDisplay : MonoBehaviour
{
    [SerializeField] private Text itemName;
    [SerializeField] private Image image;
    [SerializeField] private CraftSlot slot1;
    [SerializeField] private CraftSlot slot2;
    [SerializeField] private CraftSlot slot3;
    [SerializeField] private Button button;
    private CraftableItem item;

    public CraftableItem Item { get => item; set { item = value;SetItem(); } }

    private void SetItem() {
        itemName.text = Item.Weapon.Data.Data.Name;
        image.sprite = Item.Weapon.Data.Data.Sprite;
        slot1.SetSlot(item.Slot1);
        slot2.SetSlot(item.Slot2);
        slot3.SetSlot(item.Slot3);
        button.onClick.AddListener(item.CreateItem);
    }
}
