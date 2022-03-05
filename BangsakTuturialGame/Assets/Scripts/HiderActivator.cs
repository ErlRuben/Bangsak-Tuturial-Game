using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HiderActivator : MonoBehaviour
{
    public NavMeshAgent Hider1;
    public NavMeshAgent Hider2;
    public NavMeshAgent Hider3;
    public NavMeshAgent Hider4;
    public Transform Player;
    public bool isEntered = false;
    
    void Update()
    {
        if(isEntered == true){
           StartCoroutine(AIWaitFunction());
        }
    }
    private void OnTriggerEnter()
    {
        isEntered = true;
    }
    IEnumerator AIWaitFunction()
    {
        yield return new WaitForSeconds(2f);
        Hider1.SetDestination(Player.position);
        yield return new WaitForSeconds(5f);
        Hider2.SetDestination(Player.position);
        yield return new WaitForSeconds(5f);
        Hider3.SetDestination(Player.position);
        yield return new WaitForSeconds(5f);
        Hider4.SetDestination(Player.position);
    }
}
