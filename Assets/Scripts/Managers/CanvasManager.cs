using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CanvasManager : MonoBehaviour
{
    public static event UnityAction pause;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject furnaceMenu;
    [SerializeField] private GameObject equipmentWindow;
    [SerializeField] private GameObject weaponInvent;
    [SerializeField] private GameObject inventCanvas;
    [SerializeField] private GameObject materialCanvas;
    [SerializeField] private GameObject oresCanvas;
    [SerializeField] private GameObject potionCanvas;
    [SerializeField] private GameObject alchemyCanvas;
    [SerializeField] private GameObject bluePrintCanvas;
    [SerializeField] private GameObject craftCanvas;
    [SerializeField] private GameObject bedCanvas;
    [SerializeField] private GameObject advanceTimeCanvas;
    [SerializeField] private GameObject teleportCanvas;
    //Bank Canvas
    //Knight Office Canvas
    //Town store


    private void Start() {
        GameManager.pauseGame += PauseMenuControl;
        InteractArea.potionBrewCanvas += PotionCanvasControl;
        InteractArea.furnanceCanvas += FurnanceCanvasControl;
        InteractArea.alchemyCanvas += AlchemyControl;
        InteractArea.bluePrintCanvas += BluePrintControl;
        InteractArea.craftingCanvas += CraftCanvasControl;
        InteractArea.bedCanvas += BedCanvasControl;
        TimeManager.canvasControl += AdvanceTimeControl;
        //InteractArea.bankCanvas+=
        //InteractArea.teleporterCanvas+=
    }
    public void PauseMenuControl(bool val) {
        pauseMenu.SetActive(val);
    }
    public void EquipmentWindow(bool val) {
        equipmentWindow.SetActive(val);
    }
    public void WeaponInventControl(bool val) {
        weaponInvent.SetActive(val);
    }
    public void InventCanvasControl(bool val) {
        inventCanvas.SetActive(val);
    }
    public void MaterialCanvasControl(bool val) {
        materialCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void OreMaterialCanvasControl(bool val) {
        oresCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void PotionCanvasControl(bool val) {
        potionCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void FurnanceCanvasControl(bool val) {
        furnaceMenu.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void AlchemyControl(bool val) {
        alchemyCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void BluePrintControl(bool val) {
        bluePrintCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void CraftCanvasControl(bool val) {
        craftCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void BedCanvasControl(bool val) {
        bedCanvas.SetActive(val);
        if (pause != null) {
            pause();
        }
    }
    public void AdvanceTimeControl(bool val) {
        advanceTimeCanvas.SetActive(val);
        bedCanvas.SetActive(false);
    }
    public void CloseAll() {
        pauseMenu.SetActive(false);
        equipmentWindow.SetActive(false);
        weaponInvent.SetActive(false);
        inventCanvas.SetActive(false);
        materialCanvas.SetActive(false);
        oresCanvas.SetActive(false);
        potionCanvas.SetActive(false);
        furnaceMenu.SetActive(false);
        alchemyCanvas.SetActive(false);
        bluePrintCanvas.SetActive(false);
        craftCanvas.SetActive(false);
        advanceTimeCanvas.SetActive(false);
        bedCanvas.SetActive(false);
    }
}
