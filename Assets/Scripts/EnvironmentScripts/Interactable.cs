using UnityEngine;

public class Interactable : MonoBehaviour {
    private bool canInteract;
    public enum InteracableType { Ores, Weapon,Material ,AlchemyTable, Furnance, CraftingTable, BluePrintStation, PotionBrewing, Bed, Bank, Teleporter}
    [SerializeField] private InteracableType type;
    public InteracableType Type { get => type; set => type = value; }
}
