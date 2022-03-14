using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class AttackerSideFinal : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject ChangeSideUI;
    public GameObject GameChecker;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Attackers"){
            PlayerCharacter.GetComponent<Controller>().enabled = false;
            PlayerCamera.GetComponent<MouseLook>().enabled = false;
            ChangeSideUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameChecker.GetComponent<SaveData>().DoneGames();
        }
    }
}