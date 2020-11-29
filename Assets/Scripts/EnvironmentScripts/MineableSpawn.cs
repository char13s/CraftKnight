using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableSpawn : MonoBehaviour
{
    [SerializeField] private Mineables ore;
    private Mineables mineable;
    private bool mined;

    public bool Mined { get => mined; set { mined = value; if (value) { StartCoroutine(WaitToGrowNew()); } } }

    private IEnumerator WaitToGrowNew() {
        Debug.Log("Spawn in progress");
        YieldInstruction wait = new WaitForSeconds(2);//NEXT DAY
        yield return wait;
        Mined = false;
        mineable=Instantiate(ore,transform.position,Quaternion.identity);
        mineable.Spawn = this;
    }
    
}
