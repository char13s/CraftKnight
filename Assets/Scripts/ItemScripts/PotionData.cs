using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PotionData {
    [SerializeField] private ItemData data = new ItemData();

    public ItemData Data { get => data; set => data = value; }
}
