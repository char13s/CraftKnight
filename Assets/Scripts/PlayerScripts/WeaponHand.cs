using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WeaponHand : MonoBehaviour {
    [SerializeField] private WeaponManager weapons;
    private WeaponInventSlot currentWeapon;
    //[SerializeField] private GameObject weapon;
    private Weapon weapon;
    private bool weaponHeld;
    private TrailRenderer trail;
    private GameObject hitbox;

    public static event UnityAction<float,Elements> sendAttack;
    // Start is called before the first frame update
    void Start() {
        //weapons = WeaponManager.GetWeaponManager();
        GeneralAnimationEvents.trailControl += TrailControl;
        PlayerBase.downWeapon += WeaponDown;
        AttackStates.trailControl += TrailControl;
    }
    public void SummonWeapon(WeaponInventSlot slot) {
        if (!weaponHeld) {
            currentWeapon = slot;
            weapon = Instantiate(weapons.CallWeapon(currentWeapon.Item.WeaponId), transform);
            if (sendAttack != null) {
                sendAttack(currentWeapon.Item.AttackPowah,currentWeapon.Item.Elementalype);
            }
            weapon.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            
            weaponHeld = true;
            trail = weapon.Trail;
            
        }
        
    }
    private void WeaponDown() {
        if (weaponHeld) {
            weapon.DownWeapon();
            
            weaponHeld = false;
        }
    }
    private void TrailControl(bool val) {
        if (trail != null) {
            trail.emitting = val;
            weapon.Hitbox.SetActive(val);
        }
        else {
            
        }
    }
}
