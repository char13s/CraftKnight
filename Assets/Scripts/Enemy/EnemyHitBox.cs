using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHitBox : MonoBehaviour
{
    [SerializeField]private float attack;
    [SerializeField] private Elements element;
    [SerializeField] private EnemyBaseScript enemy;

    [Header("Effects")]
    [SerializeField] private GameObject fireEffect;
    [SerializeField] private GameObject nullEffect;
    public static event UnityAction<float> damage;
    public float Attack { get => attack; set => attack = value; }

    private void ElementOfAttack(GameObject obj) {
        switch (element) {
            case Elements.Fire:
                Instantiate(fireEffect,obj.transform.position,Quaternion.identity);
                break;
            default:
                Instantiate(nullEffect, obj.transform.position, Quaternion.identity);
                break;
        }
    }
    private void OnTriggerEnter(Collider other) {

        ElementOfAttack(other.gameObject);
        if (damage != null) {
            //damage();///Mathf.Clamp(enemy.Attack-player.Defense,1,99999);
        }
    }
}
