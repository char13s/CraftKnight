using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DashState : StateMachineBehaviour
{
    [SerializeField] private float moveSpeed;
    public static event UnityAction clearLayers;
    public static event UnityAction dash;
    public static event UnityAction stop;
    public static event UnityAction stopDash;
    private PlayerBase player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        player = PlayerBase.GetPlayer();
        if (clearLayers != null) {
            clearLayers();
        }
        //
        //player.Rbody.AddForce(player.transform.forward * moveSpeed, ForceMode.Impulse);
        if (dash != null) {
            dash();
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (stop != null) {
            stop();
        }
        if (stopDash != null) {
            stopDash();
        }
    }
}
