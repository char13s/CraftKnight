using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BaseBehavior : StateMachineBehaviour
{
    public static event UnityAction<bool> sendAttack;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (sendAttack != null) {
            sendAttack(false);
        }
    }
}
