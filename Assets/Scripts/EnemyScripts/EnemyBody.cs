using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    [SerializeField] private EnemyBasics enemy;
    [SerializeField] Weapon.WeaponType weakness;
    [SerializeField] Weapon.WeaponType strongAgainst;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Weapon>()) {
            Weapon weapon =other.GetComponent<Weapon>();
            PrecieveDamage(weapon);
        }
    }
    private void PrecieveDamage(Weapon weapon) {
        if (weapon.Type == weakness) {
            enemy.Health -= (weapon.Damage * 2);
        }
        else if (weapon.Type == strongAgainst) {
            enemy.Health -= (weapon.Damage / 2);
        }
        else {
            enemy.Health -= weapon.Damage;
        }
    }
}
