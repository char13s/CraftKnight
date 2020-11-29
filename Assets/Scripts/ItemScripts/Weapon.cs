using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data = new WeaponData();
    [SerializeField] private GameObject fadeEffect;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private GameObject hitbox;
    private WeaponInventory invent;

    public WeaponData Data { get => data; set => data = value; }
    public TrailRenderer Trail { get => trail; set => trail = value; }
    public GameObject Hitbox { get => hitbox; set => hitbox = value; }

    private void OnDestroy() {
        
    }
    private void Start() {
        invent = WeaponInventory.GetEquipmentInvent();
        SwordAnimations.downWeapon += DownWeapon;
    }
    public void PickUp() {
        invent.AddToInvent(Data);
        Instantiate(fadeEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    public void DownWeapon() {
        Instantiate(fadeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
