using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerBase player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBase.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
