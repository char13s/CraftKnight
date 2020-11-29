using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    public enum Tier {low, mid, high }
    public enum BodyType {soft, hard }
    public enum States { }
    private NavMeshAgent nav;
    private Animator anim;
    private Rigidbody rbody;
    #region Animation parameters
    private bool attack;
    private bool walk;
    #endregion
    #region Stats
    [Header("Enemy stats")]
    [SerializeField] private Tier tier;
    [SerializeField]private int health;
    [SerializeField]private int attackPower;
    private bool dead;
    private bool hit;
    #endregion
    #region Effects


    #endregion
    #region Obj refs
    [SerializeField] private CraftMaterial drop;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject hitBox;
    #endregion

    private PlayerBase player;
    private float Distance => Vector3.Distance(player.transform.position,transform.position);
    #region Getters and Setters
    public int Health { get => health; set { Mathf.Clamp(health, 0, 9999999999999);DeathControl(); Debug.Log("nigga"); } }
    public bool Dead { get => dead; set { dead = value; } }

    public bool Hit { get => hit; set => hit = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }
    public bool Attack { get => attack; set { attack = value; anim.SetBool("Attack",attack); } }
    #endregion
    private void Awake() {
        nav = GetComponent<NavMeshAgent>();
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBase.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Distance < 10f && Distance > 1.5F) {
            Follow();
        }
        else if (Distance > 1.5F) {
            AttackState();
        }
        else {

        }
    }
    private void DeathControl() {
       // switch (tier) {
       //     case Tier.low:
       //         break;
       // }
        if (drop != null) {
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject, 1);
        }
    }
    private void HealthManagement() {
        if (health <= 0) {
            Dead = true;
            
        }
    }
    private void Follow() {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
    }
    private void HitBoxControl(int val) {
        if (val==0) {
            hitBox.SetActive(false);
        }
        else{
            hitBox.SetActive(true);
        }
    }
    private void AttackState() {
        Attack = true;
    }
}
