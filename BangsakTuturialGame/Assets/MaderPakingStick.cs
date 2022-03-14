using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaderPakingStick : MonoBehaviour
{
    public GameObject UIOpen;
    public GameObject StickClose;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Seeker"){
            UIOpen.SetActive(true);
            StickClose.SetActive(false);
            var Findobj = GameObject.Find("SeekerAI");
            Destroy(Findobj);
        }
    }
}
