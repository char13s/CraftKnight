using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSlot : MonoBehaviour
{
    private PhysicalItem item;

    public void SetItem(PhysicalItem phyItem) {
        item = phyItem;
    }
    public void Use() {
        item.UseItem();
    }
}
