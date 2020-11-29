using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData data = new ItemData();

    public ItemData Data { get => data; set => data = value; }
}
