using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerShootInside : MonoBehaviour
{
    public Transform AITransformSeeker;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "HiderAi"){
            var target = GameObject.Find("HiderAi").transform;
            AITransformSeeker.LookAt(target);
        }
        else if(other.gameObject.name =="HiderAii"){
            var targett = GameObject.Find("HiderAii").transform;
            AITransformSeeker.LookAt(targett);
        }
        else if(other.gameObject.name =="HiderAiii"){
            var targettt = GameObject.Find("HiderAiii").transform;
            AITransformSeeker.LookAt(targettt);
        }
        else if(other.gameObject.name == "Character"){
            var targettt = GameObject.Find("Character").transform;
            AITransformSeeker.LookAt(targettt);
        }
    }
}
