using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackStates : StateMachineBehaviour {
    [SerializeField] private float knockPower;
    [SerializeField] private float startTrail;
    [SerializeField] private float endTrail;
    public static event UnityAction<bool> attackControl;
    public static event UnityAction<float> sendKnockPower;
    public static event UnityAction<bool> trailControl;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (attackControl != null) {
            attackControl(false);
        }
        if (sendKnockPower != null) {
            sendKnockPower(knockPower);
        }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (animatorStateInfo.normalizedTime >= startTrail && animatorStateInfo.normalizedTime <= endTrail) {

            if (trailControl != null) {
                trailControl(true);
            }
        }
        else if (animatorStateInfo.normalizedTime >= endTrail) {
            if (trailControl != null) {
                trailControl(false);
            }
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (sendKnockPower != null) {
            sendKnockPower(0);
        }

    }
}
