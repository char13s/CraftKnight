using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionBar : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject interactionBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //GetComponent of interactable then access sprite in switch statement
    
    }
}
