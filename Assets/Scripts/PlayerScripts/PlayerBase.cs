using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class PlayerBase : MonoBehaviour {
    private Vector3 displacement;
    private int currentWeapon;
    private bool playerSeal;
    private static PlayerBase instance;
    public static PlayerBase GetPlayer() => instance;
    #region Stats
    private float health;
    private float stamina;
    private float mp;
    private float attackPower;
    private Elements typeUsing;
    private float defense;
    private int money;
    #endregion
    #region Aniamtion states
    private bool moving;
    private bool attacking;
    private int weaponId;
    private int cmdInput;
    private bool attack;
    private bool onHit;
    private bool dash;
    #endregion
    #region Object refs
    [SerializeField] private GameObject interactionArea;
    [SerializeField] private WeaponInventSlot[] arsenal;
    [SerializeField] private WeaponHand swordHand;
    [SerializeField] private WeaponHand spearHand;
    [SerializeField] private GameObject hitBox;
    [SerializeField] private GameObject knockBackBox;
    [SerializeField] private HurtBox hurtBox;
    #endregion
    #region Outside Scripts
    private NavMeshAgent nav;
    private Animator anim;
    private Rigidbody rbody;
    private SwordAnimations swordAnims;
    private SpearAnimations spearAnims;
    #endregion
    #region Aniamtion Layers
    private int swordLayer;
    private int spearLayer;
    private int bigWeaponLayer;
    #endregion
    #region Unity Events
    public static event UnityAction downWeapon;
    public static event UnityAction<float> sendHealth;
    public static event UnityAction<float> sendMp;
    public static event UnityAction<float> sendStamina;
    #endregion
    #region Getters and Setters

    public bool Moving { get => moving; set { moving = value; anim.SetBool("Moving", moving); } }

    public int CurrentWeapon { get => currentWeapon; set { currentWeapon = Mathf.Clamp(value, 0, 2); } }

    public int WeaponId { get => weaponId; set { weaponId = value; anim.SetInteger("WeaponId", weaponId); } }

    public bool Attack { get => attack; set { attack = value; anim.SetBool("Attack", attack); } }

    public Elements TypeUsing { get => typeUsing; set => typeUsing = value; }
    public float AttackPower { get => attackPower; set => attackPower = value; }
    public bool OnHit { get => onHit; set { onHit = value; anim.SetBool("Hit", onHit); } }

    public float Defense { get => defense; set => defense = value; }
    public float Health { get => health; set { health = value; if (sendHealth != null) { sendHealth(health); } } }

    public float Stamina { get => stamina; set { stamina = value; if (sendStamina != null) { sendStamina(stamina); } } }
    public float Mp { get => mp; set { mp = value; if (sendMp != null) { sendMp(mp); } } }

    public bool Dash { get => dash; set { dash = value; anim.SetBool("Dash", dash); } }

    public Rigidbody Rbody { get => rbody; set => rbody = value; }
    public int Money { get => money; set => money = value; }

    #endregion
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        //nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        Rbody = GetComponent<Rigidbody>();
        swordAnims = GetComponentInChildren<SwordAnimations>();
        spearAnims = GetComponentInChildren<SpearAnimations>();
        swordLayer = anim.GetLayerIndex("SwordLayer");
        spearLayer = anim.GetLayerIndex("SpearLayer");

        //bigWeaponLayer = anim.GetLayerIndex("BigWeaponLayer");
    }
    void Start() {
        GameManager.pauseGame += PlayerSealing;
        SceneRelocation.sendSpawn += MovePlayer;
        MovingState.sendSpeed += SpeedControl;
        MovingState.stop += ZeroVelocity;
        MovingState.clearLayers += ClearLayers;
        AttackStates.attackControl += AttackControl;
        BaseBehavior.sendAttack += AttackControl;
        SkillState.defuseWeaponId += DefuseWeaponId;
        WeaponHand.sendAttack += RecieveAttackStat;
        HurtBox.damaged += HealthController;
        DashState.dash += HitTheGas;
        DashState.stop += ZeroVelocity;
        DashState.stopDash += StopDash;
        DashState.clearLayers += ClearLayers;
        TeleportManager.sendSpot += MovePlayer;
    }
    void Update() {
        if (!playerSeal) { 
        GetInput();
        }
    }
    private void GetInput() {
        if (!dash) {
            MovementInput();
        }
        BasicAttack();
        SkillButton();
        WeaponSwitching();
        AdvanceMovement();
        Interact();
        Dashu();
    }
    private void MovementInput() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        displacement = Vector3.Normalize(new Vector3(x, 0, y));
        if (!dash) {

            //transform.position = displacement * speed;
            Move(x, y);
        }
    }
    private void Move(float x, float y) {
        if (x != 0 || y != 0) {
            Moving = true;
            transform.rotation = Quaternion.LookRotation(displacement);
        }
        else {
            Moving = false;
        }
    }
    private IEnumerator WaitToLand() {
        yield return null;
        yield return null;
        yield return null;
        //nav.enabled = true;
    }
    private IEnumerator TurnOffInteract() {
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        interactionArea.SetActive(false);
    }

    private void BasicAttack() {//square
        if (Input.GetButtonDown("Fire3")) {
            ClearLayers();
            ArsenalControl();
            Attack = true;
        }

    }
    private void ArsenalControl() {
        if (arsenal[CurrentWeapon].Item != null) {
            switch (arsenal[CurrentWeapon].Item.Type) {
                case WeaponData.WeaponType.Sword:

                    anim.SetLayerWeight(swordLayer, 1);
                    swordHand.SummonWeapon(arsenal[CurrentWeapon]);
                    swordAnims.enabled = true;
                    break;
                case WeaponData.WeaponType.Spear:
                    anim.SetLayerWeight(spearLayer, 1);

                    spearHand.SummonWeapon(arsenal[CurrentWeapon]);
                    break;
            }
        }
    }
    public void ClearLayers() {
        if (downWeapon != null) {
            downWeapon();
        }
        anim.SetLayerWeight(swordLayer, 0);
        anim.SetLayerWeight(spearLayer, 0);
        anim.SetLayerWeight(bigWeaponLayer, 0);
        swordAnims.enabled = false;
    }
    private void WeaponSwitching() {
        if (Input.GetButtonDown("Fire4")) {// triangle button
            ClearLayers();
            if (CurrentWeapon == 2) {
                CurrentWeapon = 0;
            }
            else {
                CurrentWeapon++;
            }
            ArsenalControl();
        }
    }
    private void SkillButton() {
        if (Input.GetButtonDown("Fire2")) {//Circle
            if (arsenal[currentWeapon].Item != null) {
                WeaponId = arsenal[currentWeapon].Item.WeaponId;
                Mp -= 5;
            }
            //Make this type of move take up some typa meter
        }
    }
    private void AdvanceMovement() {
        //if (Input.GetButtonDown("")) {// probably some R2 trigger shit
        //
        //}
    }
    private void Interact() {
        if (Input.GetButtonDown("Interact")) {//X button      
            ClearLayers();
            interactionArea.SetActive(true);
            StartCoroutine(TurnOffInteract());
        }
    }
    private void Dashu() {
        if (Input.GetButtonDown("Fire1")) {//X button      
            Dash = true;
        }
    }
    #region Event Handlers Methods
    private void DefuseWeaponId() {
        WeaponId = 0;
    }
    private void AttackControl(bool val) {
        Attack = val;
    }
    private void MovePlayer(GameObject spawn) {
        //nav.enabled = false;
        transform.position = spawn.transform.position;
        StartCoroutine(WaitToLand());
    }
    private void SpeedControl(float speed) {

        Rbody.velocity = speed * displacement;
        //Debug.Log(rbody.velocity);
        //nav.Move(speed * displacement);

    }
    private void WeaponControl(bool val) {

    }
    private void RecieveAttackStat(float attackStat, Elements elements) {
        AttackPower = attackStat;
        TypeUsing = elements;
    }
    private void HealthController(float val) {
        Health += val;
    }
    private void HitTheGas() {
        //if (displacement == Vector3.zero) {
        ZeroVelocity();
        StartCoroutine(WaitDash());
        Debug.Log("forward: " + transform.forward);
        //}
        //else {
        //    Debug.Log("displacement: "+displacement);
        //    rbody.AddForce(displacement * 15, ForceMode.Impulse);
        //}

        Dash = false;
    }
    private void ZeroVelocity() {
        rbody.velocity = new Vector3(0, 0, 0);
    }
    //private IEnumerator MpCharge() {
    //    YieldInstruction wait = new WaitForSeconds();
    //    while (isActiveAndEnabled & mp < 100) {
    //
    //    }
    //}
    private IEnumerator WaitDash() {
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        Rbody.AddForce(transform.forward * 15, ForceMode.Impulse);
    }
    private void StopDash() {
        Dash = false;
    }
    private void AddItUp(int val) {
        Money += val;
    }
    private void PlayerSealing(bool val) {
        playerSeal = val;
    }
    private void MpGain() {
        mp += 2;
    }
    #endregion
}


