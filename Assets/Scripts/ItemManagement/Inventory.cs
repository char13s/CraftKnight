using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private List<ItemData> invent=new List<ItemData>();
    private static Inventory instance;

    public List<ItemData> Invent { get => invent; set => invent = value; }

    public static Inventory GetInvent() => instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void AddItem(PhysicalItem item) {

    }
    //private void 
}
