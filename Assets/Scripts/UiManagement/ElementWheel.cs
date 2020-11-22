using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElementWheel : MonoBehaviour
{
    private GameObject menu;
    private GameObject[] elements;
    private float lStick;

    public float LStick { get => lStick; set => lStick = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ControlWheel() {
        float x = Input.GetAxis("Horizontal");
        LStick = x;
        if (x > 0 && x <= 0.2) {

        }
    }
}
