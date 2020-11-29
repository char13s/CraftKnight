using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Teleport : MonoBehaviour {

    [SerializeField] private GameObject workShopSpot;

    public static event UnityAction<GameObject> sendSpot;
    public void BackToShop() {
        if (sendSpot != null) {
            sendSpot(workShopSpot);
        }
    }
}
