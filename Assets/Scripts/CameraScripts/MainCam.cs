using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    private static MainCam instance;
    public static MainCam GetCam() => instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
}
