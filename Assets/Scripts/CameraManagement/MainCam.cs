using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    private static Transform xZOrientation;
    public Transform XZOrientation { get => xZOrientation; set => xZOrientation = value; }
    
    // Start is called before the first frame update
    private void Awake() {
        xZOrientation = new GameObject("xZOrienatation").transform;
        xZOrientation.transform.SetParent(transform);
    }
    private void Start() {
        //xZOrientation.transform.SetParent(xZOrientation.transform);
    }

    //   
    //
    //
    /// Update is called once per frame
    void Update() {
        xZOrientation.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
   //
   //   
   //
}
