using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blueprint : MonoBehaviour {

    [SerializeField] BluePrintType weaponType;
    [SerializeField] BluePrintType elementType;
    [SerializeField] BluePrintType attackType;

    private bool unlocked;
    private Button button;
    public BluePrintType WeaponType { get => weaponType; set => weaponType = value; }
    public BluePrintType ElementType { get => elementType; set => elementType = value; }
    public BluePrintType AttackType { get => attackType; set => attackType = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }
    private void Awake() {
        button = GetComponent<Button>();
    }
    private void Display() {

    }
}
