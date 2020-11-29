using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Elements type;
    [SerializeField] private Elements weakness;
    [SerializeField] private Elements advantage;

    public Elements Weakness { get => weakness; set => weakness = value; }
    public Elements Advantage { get => advantage; set => advantage = value; }
}
