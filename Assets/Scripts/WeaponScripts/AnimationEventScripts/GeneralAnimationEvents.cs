using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GeneralAnimationEvents : MonoBehaviour
{
    public static event UnityAction<bool> trailControl;
    private PlayerBase player;

    [SerializeField] private GameObject trail;
    // Start is called before the first frame update
    void Start() {
        player = PlayerBase.GetPlayer();
    }

    public void FadeWeapon() {
        player.ClearLayers();
    }
    private void TrailControl(int val) {
        if (val == 1) {
            if (trailControl != null) {
                trailControl(true);
            }
        }
        else {
            if (trailControl != null) {
                trailControl(false);
            }
        }
    }
}
