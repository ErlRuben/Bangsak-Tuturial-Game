using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class OutofBounds : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject ChangeSideUI;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Attackers"){
            PlayerCharacter.GetComponent<Controller>().enabled = false;
            PlayerCamera.GetComponent<MouseLook>().enabled = false;
            ChangeSideUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
