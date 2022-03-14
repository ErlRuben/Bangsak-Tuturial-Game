using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndGoal : MonoBehaviour
{
    public GameObject WinGoal;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Attackers"){
            WinGoal.SetActive(true);
        }
    }
}
