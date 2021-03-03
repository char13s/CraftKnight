using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    [SerializeField] private Element type;
    [SerializeField] private EnemyBaseScript enemy;
    private PlayerBase player;
    [Header("Effects")]
    [SerializeField] private HitSplat hitSplat;
    [SerializeField] private GameObject fireEffect;
    [SerializeField] private GameObject nullEffect;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBase.GetPlayer();
    }
    private float ManageElement() {
        if (type.Weakness == player.TypeUsing) {
            return 2f;
        }
        else if (type.Advantage == player.TypeUsing) {
            return 0.5f;
        }
        else {
            return 1;
        }
    }
    private void ElementSplat() {
        switch (player.TypeUsing) {
            case Elements.Fire:
                Instantiate(fireEffect, transform.position, Quaternion.identity);
                break;
            case Elements.Null:
                Instantiate(nullEffect, transform.position, Quaternion.identity);
                break;
        }
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Ouch");
        enemy.Health-=Mathf.Clamp((int)(player.AttackPower*ManageElement()),1,99999999);
        Debug.Log(Mathf.Clamp((int)(player.AttackPower * ManageElement()), 1, 99999999));
        Instantiate(hitSplat,transform.position,Quaternion.identity);
        ElementSplat();
        int damage=(int)(player.AttackPower * ManageElement());
        hitSplat.Text.text = damage.ToString();
        Debug.Log((int)(player.AttackPower * ManageElement()));
        
    }
}
