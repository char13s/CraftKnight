using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintManager : MonoBehaviour
{
    [SerializeField] Blueprint[] bluePrints = new Blueprint[2];
    [SerializeField] BluePrintElementList weaponBase;
    [SerializeField] BluePrintElementList element;
    [SerializeField] BluePrintElementList attackType;
    public void CreateBluePrint() {
        foreach (Blueprint bp in bluePrints) {
            if (bp != null) {
                if (bp.WeaponType == weaponBase.Element.Type
                    &&bp.ElementType == element.Element.Type
                    &&bp.AttackType == attackType.Element.Type
                  ) {
                    if (bp.Unlocked) {
                        Debug.Log("Blueprint made");
                        //send message saying you already have this blueprint
                    }
                    else {
                        
                        bp.Unlocked = true;
                        return;
                        //make blueprint sprite pop up and a message congratulating player
                    }
                }
                //Print there is no weapon like this
                Debug.Log("Data Not Found");
            }
            else {
                return;
            }
        }
    }
    private void UnCheckEm() {
        

    }
}
