using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponData
{
    public enum WeaponType {Sword,Spear,GreatSword,Arrow,MagicWand,Hammer }
    [SerializeField] private WeaponType type;
    [SerializeField] private ItemData data = new ItemData();
    [SerializeField] private int weaponId;
    [SerializeField] private int attackPowah;
    [SerializeField] private string ability;
    [SerializeField] private Elements elementalype;
    public int WeaponId { get => weaponId; set => weaponId = value; }
    public int AttackPowah { get => attackPowah; set => attackPowah = value; }
    public ItemData Data { get => data; set => data = value; }
    public string Ability { get => ability; set => ability = value; }
    public WeaponType Type { get => type; set => type = value; }
    public Elements Elementalype { get => elementalype; set => elementalype = value; }
}
