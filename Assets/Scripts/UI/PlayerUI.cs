using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider mpBar;
    [SerializeField] private Slider stamina;
   
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
        healthBar.value += val;
    }
    private void ChangeMp(float val) {
        mpBar.value += val;
    }
    private void ChangeStamina(float val) {
        stamina.value += val;
    }
}
