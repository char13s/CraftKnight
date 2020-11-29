using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager GetItemManager() => instance;
    [SerializeField] private CraftMaterial[] items = new CraftMaterial[10];
    // Start is called before the first frame update
    void Start() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public ItemData GetItem(int id) => items[id-1].CraftData.Data;
}
