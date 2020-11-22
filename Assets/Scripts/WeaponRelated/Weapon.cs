using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PhysicalItem
{
    public enum WeaponType {sword, katana, knuckles, spear }
    [SerializeField] private WeaponType type;
    #region Weapon Stats
    [Header("Weapon Stats")]
    [SerializeField]private int damage;
    #endregion
    public WeaponType Type { get => type; set => type = value; }
    public int Damage { get => damage; set => damage = value; }

    
}
