using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    [SerializeField] private int rent;
    // Start is called before the first frame update
    private void Awake() {
        rent = 30000;
    }
    void Start()
    {
        
    }

    private void AdjustRent(int val) {
        rent += val;
    }
    private void CheckRent() {
        if (rent > 0) {
            //DeleteHalfOfInvent
        }
        else {
            rent = 30000;
        }
    }
}
