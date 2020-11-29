using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private PotionData data = new PotionData();

    public PotionData Data { get => data; set => data = value; }
    private PotionInventory invent;
    private void Start() {
        invent = PotionInventory.GetEquipmentInvent();
    }
    public void PickUp() {
        invent.AddToInvent(data);
        Destroy(gameObject);
    }
}
