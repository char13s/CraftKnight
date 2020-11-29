using UnityEngine;
using UnityEngine.Events;
public class InteractArea : MonoBehaviour {
    public static event UnityAction<bool> furnanceCanvas;
    public static event UnityAction<bool> potionBrewCanvas;
    public static event UnityAction<bool> craftingCanvas;
    public static event UnityAction<bool> alchemyCanvas;
    public static event UnityAction<bool> bluePrintCanvas;
    public static event UnityAction<bool> bedCanvas;
    public static event UnityAction<bool> bankCanvas;
    public static event UnityAction teleporter;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Interactable>() != null) {
            switch (other.GetComponent<Interactable>().Type) {
                case Interactable.InteracableType.Weapon:
                    other.GetComponent<Weapon>().PickUp();
                    break;
                case Interactable.InteracableType.Ores:
                    other.GetComponent<Ore>().PickUp();
                    break;
                case Interactable.InteracableType.AlchemyTable:
                    if (alchemyCanvas != null) {
                        alchemyCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.BluePrintStation:
                    if (bluePrintCanvas != null) {
                        bluePrintCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.CraftingTable:
                    if (craftingCanvas != null) {
                        craftingCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.Furnance:
                    if (furnanceCanvas != null) {
                        furnanceCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.PotionBrewing:
                    if (potionBrewCanvas != null) {
                        potionBrewCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.Material:
                    other.GetComponent<CraftMaterial>().PickUp();
                    break;
                case Interactable.InteracableType.Bed:
                    if (bedCanvas != null) {
                        bedCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.Bank:
                    if (bankCanvas != null) {
                        bankCanvas(true);
                    }
                    break;
                case Interactable.InteracableType.Teleporter:
                    if (teleporter != null) {
                        teleporter();
                    }
                    break;
            }
        }
    }
}

