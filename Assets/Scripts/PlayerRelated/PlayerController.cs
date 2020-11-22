using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    #region Animation states
    private bool moving;
    private bool attack;
    #endregion
    #region Obj refs
    [SerializeField] private MainCam cam;
    #endregion
    #region Outside Script ref
    private Animator anim;
    #endregion
    #region Constructors
    private AssignSlot squareButton;
    private AssignSlot triangleButton;
    private AssignSlot circleButton;
    #endregion
    private Vector3 displacement;
    public bool Moving { get => moving; set { moving = value;anim.SetBool("Moving",moving); } }

    public bool Attack { get => attack; set { attack = value;anim.SetBool("Attack",attack); } }

    private void Awake() {
        anim = GetComponent<Animator>();
    }
        // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    private void GetInput() {
        Movement();
        ButtonInputs();
    }
    private void ButtonInputs() {
        if (Input.GetButtonDown("Square")) {
            squareButton.Use();
        }
        if (Input.GetButtonDown("Triangle")) {
            triangleButton.Use();
        }
        if (Input.GetButtonDown("Circle")) {
            circleButton.Use();
        }
    }
    private void Movement() {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        displacement = Vector3.Normalize(new Vector3(x, 0, y));
        
            //displacement = cam.GetComponent<MainCam>().XZOrientation.TransformDirection(displacement);
        Rotate();
        Move(x,y);
    }
    private void Move(float x,float y) {
        if (x != 0||y!=0) {
            Moving = true;
        }
        else {
            Moving = false;
        }
        transform.position += displacement * speed * Time.deltaTime;
    }
    
    private void Rotate() {
        if (Vector3.SqrMagnitude(displacement) > 0.01f) {
            transform.forward = displacement;
        }
    }
}
