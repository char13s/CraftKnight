using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
[System.Serializable]
public class ItemData {
    public enum ItemType { Material, Ore, Weapon, Potion}
    [SerializeField] ItemType type;
    [SerializeField] private string name;
    [SerializeField] private int id;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int rarity;
    private int quantity;

    public Sprite Sprite { get => sprite; set => sprite = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    
    public int Rarity { get => rarity; set => rarity = value; }
    public ItemType Type { get => type; set => type = value; }
    public int Quantity { get => quantity; set => quantity = value; }
    public int Id { get => id; set => id = value; }
}
