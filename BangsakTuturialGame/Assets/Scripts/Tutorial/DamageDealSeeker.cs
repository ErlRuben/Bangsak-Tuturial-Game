using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DamageDealSeeker : MonoBehaviour
{
    //ForTagAndDeleteWhenShotAI
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject Companion;
    public GameObject LocationNew;
    public GameObject AISeeker;
    public GameObject UIText;
    public GameObject WarningUI;
    public GameObject StickDisable;
    public GameObject GameChecker;
    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Stick"){
            PlayerCharacter.transform.position = LocationNew.transform.position;
            PlayerCharacter.transform.rotation = LocationNew.transform.rotation;
            PlayerCharacter.transform.LookAt(Companion.transform);
            PlayerCharacter.GetComponent<Controller>().enabled = false;
            PlayerCamera.GetComponent<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            GameChecker.GetComponent<SaveData>().DoneGames();
            AISeeker.SetActive(false);
            WarningUI.SetActive(false);
            UIText.SetActive(true);
            StickDisable.SetActive(false);
            Destroy(WarningUI);
        }
    }
}
