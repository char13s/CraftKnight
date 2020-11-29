using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineables : MonoBehaviour
{
    [SerializeField] private MineableSpawn spawn;
    [SerializeField] private GameObject ore;
    [SerializeField] private GameObject hitEffect;
    private float sturdiness;

    public float Sturdiness { get => sturdiness; set { sturdiness = Mathf.Clamp(value,0,5); MinedCheck(); } }

    public MineableSpawn Spawn { get => spawn; set => spawn = value; }

    // Start is called before the first frame update
    void Start()
    {
        sturdiness = 5;
    }

    private void OnTriggerEnter(Collider other) {
        Sturdiness--;
        Instantiate(hitEffect,transform.position,Quaternion.identity);
        Debug.Log("cha-chink");
    }
    private void MinedCheck() {
        if (sturdiness <= 0&& !Spawn.Mined) {
            Spawn.Mined = true;
            Instantiate(ore, transform.position, Quaternion.identity);
            //Instantiate(ore, transform.position, Quaternion.identity);
            Destroy(gameObject, 1);
        }
    }
}
