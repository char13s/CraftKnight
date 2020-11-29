using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{//This script knocks and other object this object his hitting back
    private float knockBackStrength;

    private void Start() {
        AttackStates.sendKnockPower += RecieveKnockPower;
    }
    private void RecieveKnockPower(float power) {
        knockBackStrength = power;
    }
    private void OnTriggerEnter(Collider other) {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null) {
            Debug.Log(knockBackStrength);
            Debug.Log("Smack");
            Vector3 direction = other.transform.position - transform.position;
            rb.AddForce(direction.normalized * knockBackStrength, ForceMode.Impulse);
        }
    }
}
