using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public enum ItemType {Sword,Spear, MagicStaff }
    [SerializeField] private ItemType type;

    public void Use() {
        switch (type) {
            case ItemType.Sword:
                //Summon sword, switch to swordlayer, send event to say youre using sword skills
                break;
            case ItemType.Spear:

                break;
        }
    }
}
