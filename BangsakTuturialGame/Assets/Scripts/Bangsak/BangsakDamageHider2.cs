using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BangsakDamageHider2 : MonoBehaviour
{
    //ForTagAndDeleteWhenShotAI
    public GameObject AICharacter;
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject WarningUI;

    public Text CountUISeeker;
    public float countSeeker = 0;
    public GameObject NoSeekerLeft;
    public GameObject GameChecker;
    public bool isDown = false;
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        AICharacter.GetComponent<BangsakSeeker>().enabled = true;
    }
    void Update(){
        

        float f2 = float.Parse(CountUISeeker.text);
        countSeeker = f2;
    }
    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Stick"){
            countSeeker -= 1;
            CountUISeeker.text = countSeeker.ToString("0");
            Destroy(other.GetComponent<BoxCollider>());
            WarningUI.SetActive(false);
            isDown = true;  
            if(countSeeker==0){
                countSeeker = 0;
                NoSeekerLeft.SetActive(true);
                PlayerCharacter.GetComponent<Controller>().enabled = false;
                PlayerCamera.GetComponent<MouseLook>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                GameChecker.GetComponent<SaveData>().DoneGames();
            }
            AICharacter.SetActive(false);
            WarningUI.SetActive(false);
        }
        
        else if(isDown == true){
            WarningUI.SetActive(false);
        }
    }

}