using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHitBox : MonoBehaviour
{
    [SerializeField]private float attack;

    [SerializeField] private EnemyBaseScript enemy;
    public static event UnityAction<float> damage;
    public float Attack { get => attack; set => attack = value; }

    private void OnTriggerEnter(Collider other) {
        if (damage != null) {
            //damage();///Mathf.Clamp(enemy.Attack-player.Defense,1,99999);
        }
    }
}
