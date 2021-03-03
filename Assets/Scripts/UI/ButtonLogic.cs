using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonLogic : MonoBehaviour
{
    private Button button;
    private void Awake() {
        button = GetComponent<Button>();
    }
    public void OnClick() {
        button.interactable = false;
        StartCoroutine(DisableClick());
    }
    private IEnumerator DisableClick() {
        YieldInstruction wait = new WaitForSeconds(1);
        yield return wait;
        button.interactable = true;
    }
}
