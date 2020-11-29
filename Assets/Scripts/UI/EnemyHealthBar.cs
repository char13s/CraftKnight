using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider health;
    [SerializeField] private EnemyBaseScript enemy;
    private MainCam cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = MainCam.GetCam();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
