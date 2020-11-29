using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MovingState : StateMachineBehaviour
{
    [SerializeField] private float speed;
    public static event UnityAction<float> sendSpeed;
    public static event UnityAction clearLayers;
    public static event UnityAction stop;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (sendSpeed != null) {
            sendSpeed(speed);
        }
        if (clearLayers != null) {
            clearLayers();
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (stop != null) {
            stop();
        }
    }
}
