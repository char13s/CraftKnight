using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider mpBar;
    [SerializeField] private Slider stamina;
    [SerializeField] private GameObject hitSplatlocation;
    [SerializeField] private HitSplat hitSplat;
    private void Awake() {
        healthBar.maxValue = 100;
        healthBar.value = 100;
        mpBar.maxValue = 100;
        mpBar.value = 100;
        //stamina.maxValue = 100;
        //stamina.value = 100;
    }
    void Start()
    {
        PlayerBase.sendHealth += ChangeHealth;
        PlayerBase.sendMp += ChangeMp;
        PlayerBase.sendStamina += ChangeStamina;
    }
    private void ChangeHealth(float val) {
        Debug.Log(val);
        healthBar.value = val;
        Instantiate(hitSplat,hitSplatlocation.transform);
        hitSplat.Text.text = val.ToString();
    }
    private void ChangeMp(float val) {
        mpBar.value += val;
    }
    private void ChangeStamina(float val) {
        stamina.value += val;
    }
}
