using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponStatsDisplay : MonoBehaviour
{
    [SerializeField] private Text attackStat;
    [SerializeField] private Text ability;
    [SerializeField] private Text description;

    public Text AttackStat { get => attackStat; set => attackStat = value; }
    public Text Ability { get => ability; set => ability = value; }
    public Text Description { get => description; set => description = value; }
}
