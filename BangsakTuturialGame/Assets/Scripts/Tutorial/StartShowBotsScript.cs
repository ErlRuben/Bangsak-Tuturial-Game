using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShowBotsScript : MonoBehaviour
{
    public GameObject TalkSummonAI;
    public GameObject MouseUnlock;
    public GameObject player;
    public GameObject camera;
    public GameObject AIAgent;
    public GameObject Gun;
    public GameObject LocationNew;
    public Transform playerLook;
    public Transform AIposition1;
    public Transform AIposition2;
    public Transform Companion;
    public bool lookBool = false;
    public bool stoplook = false;
    public Animator BotAnim;
    void OnTriggerEnter(Collider other) {
        if(stoplook == false && other.tag == "Player"){
            StartCoroutine(DelayShowCollider());
            player.GetComponent<Controller>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            player.transform.LookAt(Companion);
            stoplook = true;
            player.transform.position = LocationNew.transform.position;
            player.transform.rotation = LocationNew.transform.rotation;
        }
    }
    public void PressedSummonHider(){
        lookBool = true;
        if(lookBool == true){
            StartCoroutine(WaitBotKill());
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    IEnumerator DelayShowCollider(){
        yield return new WaitForSeconds(0.1f);
        TalkSummonAI.SetActive(true);
        MouseUnlock.SetActive(true);
    }
    IEnumerator WaitBotKill(){
        player.transform.LookAt(Companion);
        yield return new WaitForSeconds(0.5f);
        Gun.SetActive(true);
        player.transform.LookAt(AIposition1);
        camera.GetComponent<MouseLook>().enabled = true;
        lookBool = false;
    }
}
