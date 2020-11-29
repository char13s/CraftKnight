using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private OreData data = new OreData();
    private OreInventory invent;
    private void Start() {
        invent = OreInventory.GetEquipmentInvent();
    }
    public void PickUp() {
        invent.AddToInvent(data);
        data.Quantity++;
        Debug.Log(data.Data.Name+" : "+data.Quantity);
        Destroy(gameObject);
    }
}
