using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour {
    public enum Tier { low, mid, high }
    public enum BodyType { soft, hard }
    public enum States { }
    private NavMeshAgent nav;
    private Animator anim;
    private Rigidbody rbody;
    private Coroutine updateFakeAss;
    #region Animation parameters
    private bool attack;
    private bool walk;
    #endregion
    #region Stats
    [Header("Enemy stats")]
    [SerializeField] private float attackDelay;
    [SerializeField] private Tier tier;
    [SerializeField] private int health;
    [SerializeField] private int attackPower;
    private bool dead;
    private bool hit;
    #endregion
    #region Effects


    #endregion
    #region Obj refs
    [SerializeField] private GameObject drop;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject hitBox;
    #endregion

    private PlayerBase player;
    private float Distance => Vector3.Distance(player.transform.position, transform.position);
    #region Getters and Setters
    public int Health { get => health; set { health=((int)Mathf.Clamp(value, 0, 9999999999999)); HealthManagement(); Debug.Log(health); } }
    public bool Dead { get => dead; set { dead = value; if (value) { DeathControl(); } } }

    public bool Hit { get => hit; set => hit = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }
    public bool Attack { get => attack; set { attack = value; anim.SetBool("Attack", attack); } }

    public float AttackDelay { get => attackDelay; set => attackDelay = Mathf.Clamp(value, 0, 999); }
    #endregion
    private void Awake() {
        nav = GetComponent<NavMeshAgent>();
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start() {
        player = PlayerBase.GetPlayer();
        updateFakeAss = StartCoroutine(SlowUpdate());
    }

    // Update is called once per frame
    void Update() {
        if (Distance < 10) {
            transform.rotation = Quaternion.LookRotation((transform.position - player.transform.position));
        }
        if (Distance < 10f && Distance >= 1.5F) {
            Follow();
        }
    }
    private void FakeUpdate() {
        if (Distance < 1.5F) {
            AttackState();
        }
    }
    private void DeathControl() {
        // switch (tier) {
        //     case Tier.low:
        //         break;
        // }
        Debug.Log("Dead");
        if (drop != null) {
            Instantiate(drop, transform.position, Quaternion.identity);
            
        }
        Destroy(gameObject, 1);
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
        if (val == 0) {
            Attack = false;
            hitBox.SetActive(false);
        }
        else {
            hitBox.SetActive(true);
        }
    }
    private void AttackState() {
        if (AttackDelay == 0) {
            StartCoroutine(WaitToAttack());
        }
        else {
            StartCoroutine(WaitForAttackDelay());
        }
    }
    private IEnumerator WaitToAttack() {
        YieldInstruction wait = new WaitForSeconds(0.1f);
        yield return wait;
        Attack = true;
        AttackDelay = 2;

    }
    private IEnumerator WaitForAttackDelay() {
        YieldInstruction wait = new WaitForSeconds(1);
        yield return wait;
        AttackDelay--;
    }
    private IEnumerator SlowUpdate() {
        YieldInstruction wait = new WaitForSeconds(1.5f);
        while (isActiveAndEnabled) {
            yield return wait;
            FakeUpdate();

        }

    }
}
