using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
    ItemData data = new ItemData();

    public void UseItem() {
        data.Use();
    }
}
