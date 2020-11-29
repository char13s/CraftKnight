using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BluePrintElement : MonoBehaviour
{
    private Button button;
    [SerializeField] private BluePrintType type;
    [SerializeField] private BluePrintElementList list;
    public BluePrintType Type { get => type; set => type = value; }

    private void Awake() {
        button = GetComponent<Button>();
    }
    private void Start() {
        button.onClick.AddListener(ElementSelected);
    }
    private void ElementSelected() {
        list.Element = this;
    }
}
