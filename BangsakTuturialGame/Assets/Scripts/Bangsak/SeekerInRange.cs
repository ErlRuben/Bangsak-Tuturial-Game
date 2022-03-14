using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerInRange : MonoBehaviour
{
    public GameObject WarningUI;
    
    void Start()
    {
        WarningUI.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Seeker"){
            WarningUI.SetActive(true);
        }      
        else if (other.tag == "Player"){
            WarningUI.SetActive(false);
        }
    }

}
