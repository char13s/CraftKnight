using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text time;
    [SerializeField] private GameObject sun;
    [SerializeField] private Light sunlight;
    [SerializeField] private Text additionalTime;
    [SerializeField] private Text date;
    private int addTime;
    private Coroutine watch;
    private int hours;
    private int minutes;
    private int day;

    public static event UnityAction<bool> canvasControl;
    public int Hours { get => hours; set { hours = value; SetTime();TimeChange(); } }

    public int AddTimeUp { get => addTime; set { addTime = Mathf.Clamp(value, 0, 24); TextForAddTime(); } }

    public int Day { get => day; set { day = value; DateManagement(); } }

    // Start is called before the first frame update
    void Start()
    {
        Hours = 6;
        watch= StartCoroutine(TimeLapsing());
    }
    private IEnumerator TimeLapsing() {
        YieldInstruction wait = new WaitForSeconds(48);
        while (isActiveAndEnabled) {
            yield return wait;
            Hours++;
        }
    }
    private void SetTime() {
        
        time.text = string.Format("{0:00}",Hours%24)+ " : 00";
    }
    private void ResumeTime() {
        watch= StartCoroutine(TimeLapsing());
    }
    private void StopTime() {
        StopCoroutine(watch);
    }
    public void AddTime() {
        AddTimeUp++;
    }
    public void MinusTime() {
        AddTimeUp--;
    }
    public void ConvertyTime() {
        Hours += AddTimeUp;
        AddTimeUp = 0;
        if (canvasControl != null) {
            canvasControl(false);
        }
    }
    private void TextForAddTime() {
        additionalTime.text = "+ "+AddTimeUp.ToString();
    }
    private void DaySetUp() {
        if (hours % 24 == 0) {
            Day++;
        }
    }
    private void DateManagement() {
        date.text = (Day%30).ToString();
        if (day == 30) {
            
            //rent day - If money != rent than half player invent is deleted and they lose all their money. 
        }
    }
    private void TimeChange() {
        if (hours%24 > 18||hours%24<6) {
            Color color = Color.blue;
            sunlight.color = color;
        }
        else {
            Color color = new Vector4(1,0.95f,0.84f,1);
            sunlight.color = color;
        }
        
    }
}
