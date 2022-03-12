using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBulletEnemy : MonoBehaviour
{

    public GameObject player;
    public GameObject playercamera;
    public GameObject AIseeker;
    public GameObject UIRetry;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "EnemyBullet"){
            Debug.Log("You've Been Shot By Seeker");
            player.GetComponent<Controller>().enabled = false;
            playercamera.GetComponent<MouseLook>().enabled = false;
            UIRetry.SetActive(true);
            Destroy(AIseeker.GetComponent<EnemyAiTutorial>());
            Destroy(AIseeker.GetComponent<Rigidbody>());
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
