using UnityEngine;
using UnityEngine.Events;

public class HurtBox : MonoBehaviour
{
    private PlayerBase player;
    public static event UnityAction<float> damaged;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBase.GetPlayer();
    }

    private void OnTriggerEnter(Collider other) {
        float damage =player.Defense- other.GetComponent<EnemyHitBox>().Attack;
        if (damaged != null) {
            damaged(-damage);
        }
    }
}
