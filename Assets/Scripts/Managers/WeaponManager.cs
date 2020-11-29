using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager instance;
    public static WeaponManager GetWeaponManager() => instance;
    [SerializeField] private Weapon[] weapons = new Weapon[10];
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public Weapon CallWeapon(int id) => weapons[id-1];
}
