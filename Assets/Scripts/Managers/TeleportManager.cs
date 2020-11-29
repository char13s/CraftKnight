using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TeleportManager : MonoBehaviour
{
    [SerializeField] private GameObject workShopSpot;

    public static event UnityAction<GameObject> sendSpot;
    private void Start() {
        InteractArea.teleporter += BackToShop;
    }
    private void BackToShop() {
        if (sendSpot != null) {
            sendSpot(workShopSpot);
        }
    }
}
