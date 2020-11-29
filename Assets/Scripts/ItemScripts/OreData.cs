using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class OreData
{
    [SerializeField] private ItemData data = new ItemData();
    private int quantity;
    public ItemData Data { get => data; set => data = value; }
    public int Quantity { get => quantity; set => quantity = value; }
}
