using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

public class AttackerScript : MonoBehaviour
{
    public Transform WayPoint2;
    public Transform WayPoint3;
    public NavMeshAgent DefenderNavMesh;
    public Transform DefenderAI;
    public bool Way1 = false;
    public float speed = 2f;

    public bool Attacker1=false;
    public Text CountUIAttacker;
    public float countAttacker = 0;
    public GameObject GameChecker;
    public GameObject NoAttackerLeft;
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    void Update()
    {
        PatrolAI();
        float f2 = float.Parse(CountUIAttacker.text);
        countAttacker = f2;
    }
    void PatrolAI(){
        SeenAttacker();
        if(Way1 == false){
            DefenderNavMesh.SetDestination(WayPoint2.position); 
            StartCoroutine(WaitToWalk());
        }
        else if(Way1 == true){
            DefenderNavMesh.SetDestination(WayPoint3.position);
            StartCoroutine(WaitToWalk2());
        }
        
    }
    void SeenAttacker(){
        if(Attacker1 == true){
            DefenderAI.LookAt(WayPoint2);
            speed = 4f;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Defenders"){
            countAttacker -= 1;
            CountUIAttacker.text = countAttacker.ToString("0");
            if(countAttacker == 0){
                countAttacker = 0;
                NoAttackerLeft.SetActive(true);
                PlayerCharacter.GetComponent<Controller>().enabled = false;
                PlayerCamera.GetComponent<MouseLook>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                GameChecker.GetComponent<SaveData>().DoneGames();
            }
            Destroy(gameObject);
        }
    }  

    IEnumerator WaitToWalk(){
        yield return new WaitForSeconds(10f);
        Way1 = true;
    }
    IEnumerator WaitToWalk2(){
        yield return new WaitForSeconds(10f);
        Way1 = false;
    }
}
