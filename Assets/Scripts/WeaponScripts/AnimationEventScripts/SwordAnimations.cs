using UnityEngine;
using UnityEngine.Events;
public class SwordAnimations : MonoBehaviour
{
    public static event UnityAction downWeapon;
    private PlayerBase player;

    [SerializeField] private GameObject trail;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBase.GetPlayer();
    }

    public void FadeWeapon() {
        player.ClearLayers();
    }
    //private void TrailControl(int val) {
    //    if (val == 0) {
    //        trail.SetActive(false);
    //    }
    //    else {
    //        trail.SetActive(true);
    //    }
    //}
}
