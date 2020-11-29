using UnityEngine;
using UnityEngine.Events;
public class SkillState : StateMachineBehaviour
{
    public static event UnityAction defuseWeaponId;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (defuseWeaponId != null) {
            defuseWeaponId();
        }
    }

}
