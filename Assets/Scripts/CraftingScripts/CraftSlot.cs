using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftSlot : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text quantities;
    [SerializeField] private Image materialImage;
    [SerializeField] private CraftMaterial material;
    [SerializeField] private int requiredAmount;

    public Text Name { get => name; set => name = value; }
    public Text Quantities { get => quantities; set => quantities = value; }
    public Image MaterialImage { get => materialImage; set => materialImage = value; }
    public CraftMaterial Material { get => material; set => material = value; }
    public int RequiredAmount { get => requiredAmount; set => requiredAmount = value; }

    private void Start() {
        if (Material != null) {
            SetItem();
        }
    }
    public bool CheckQuantity() {
        if (Material.CraftData.Data.Quantity >= RequiredAmount) {
            return true;
        }
        else {
            return false;
        }
    }
    public void SetSlot(CraftSlot slot) {
        Name.text = slot.name.text;
        MaterialImage.sprite = slot.MaterialImage.sprite;
        Quantities.text = slot.Quantities.text;
        Material = slot.Material;
    }
    private void SetItem() {
        if (Name != null) {
            Name.text = Material.CraftData.Data.Name;
        }
        if (MaterialImage != null) {
            MaterialImage.sprite = Material.CraftData.Data.Sprite;
        }
        if (Quantities != null) {
            Quantities.text = Material.CraftData.Data.Quantity.ToString() + "/" + RequiredAmount.ToString();
        }
    }
}
