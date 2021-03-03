using UnityEngine;
using UnityEngine.UI;
public class HitSplat : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private bool forPlayer;
    private MainCam cam;

    public Text Text { get => text; set => text = value; }
    void Start()
    {
        cam = MainCam.GetCam();
        Destroy(gameObject,3);
    }
    void Update()
    {
        transform.position += new Vector3(0,1f,0)*Time.deltaTime;
        if (!forPlayer) { 
        transform.rotation= Quaternion.LookRotation(transform.position - cam.transform.position);
        }
    }
}
