using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SummonWeapon : StateMachineBehaviour
{
    public static event UnityAction<bool> weaponControl;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (weaponControl!=null) {
            weaponControl(true);
        }
    }
}
