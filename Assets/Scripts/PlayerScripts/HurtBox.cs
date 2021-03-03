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
        if (other.GetComponent<EnemyHitBox>()) { 

        float damage =Mathf.Clamp(other.GetComponent<EnemyHitBox>().Attack-player.Defense ,1,9999);
        
        if (damaged != null) {
            damaged(-damage);
        }
        }
    }
}
