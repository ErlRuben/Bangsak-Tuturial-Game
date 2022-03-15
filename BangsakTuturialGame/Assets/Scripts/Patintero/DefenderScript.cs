using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class DefenderScript : MonoBehaviour
{
    public Transform WayPoint2;
    public Transform WayPoint3;
    public NavMeshAgent DefenderNavMesh;
    public Transform DefenderAI;
    public GameObject DefenderArmsAttack, DefenderArmsNeutral;
    public bool Way1 = false;
    public float timeroam = 1.5f;
    public bool Attacker1=false;
    //public GameObject DefenderAI;
    void Start()
    {

    }
    void Update()
    {
        PatrolAI();
    }
    void PatrolAI(){
        timeroam = 1.5f;
        SeenAttacker();
        if(Way1 == false){
            StartCoroutine(WaitToWalk());
        }
        else if(Way1 == true){
            StartCoroutine(WaitToWalk2());
        }
        
    }
    void SeenAttacker(){
        if(Attacker1 == true){
            var target = GameObject.Find("AttackerCharacter").transform;
            DefenderAI.LookAt(target);
            DefenderArmsAttack.SetActive(true);
            DefenderArmsNeutral.SetActive(false);
            timeroam = 1.5f;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "AttackerCharacter"){
            Attacker1 = true;
        }
    }  
    private void OnTriggerExit(Collider other){
        if(other.gameObject.name == "AttackerCharacter"){
            Attacker1 = false;
            DefenderArmsAttack.SetActive(false);
            DefenderArmsNeutral.SetActive(true);
        }
    }
    IEnumerator WaitToWalk(){
        DefenderNavMesh.SetDestination(WayPoint2.position);
        yield return new WaitForSeconds(timeroam);
        Way1 = true;
    }
    IEnumerator WaitToWalk2(){
        DefenderNavMesh.SetDestination(WayPoint3.position);
        yield return new WaitForSeconds(timeroam);
        Way1 = false;
    }
}
