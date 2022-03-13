using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerShootInside : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "HiderAi"){
            var target = GameObject.Find("HiderAi").transform;
            transform.LookAt(target);
        }
        else if(other.gameObject.name =="HiderAii"){
            var targett = GameObject.Find("HiderAii").transform;
            transform.LookAt(targett);
        }
        else if(other.gameObject.name =="HiderAiii"){
            var targettt = GameObject.Find("HiderAiii").transform;
            transform.LookAt(targettt);
        }
        else if(other.gameObject.name == "Character"){
            var targettt = GameObject.Find("Character").transform;
            transform.LookAt(targettt);
        }
    }
}
