using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BangsakDamageHider : MonoBehaviour
{
    //ForTagAndDeleteWhenShotAI
    public GameObject AICharacter;
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject UIRetry;
    public GameObject WarningUI;
    public GameObject BulletScript;

    public Text CountUI;
    public float countHider = 0;
    public GameObject NoHiderLeft;

    public Text CountUISeeker;
    public float countSeeker = 0;
    public GameObject NoSeekerLeft;

    public bool isDown = false;
    void Start(){
        
        AICharacter.GetComponent<BangsakHider>().enabled = true;
    }
    void Update(){
        float f1 = float.Parse(CountUI.text);
        countHider = f1;

        float f2 = float.Parse(CountUISeeker.text);
        countSeeker = f2;
    }
    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Bullet"){
            countHider -= 1;
            CountUI.text = countHider.ToString("0");
            Destroy(other.GetComponent<BoxCollider>());
            WarningUI.SetActive(false);
            isDown = true;  
            if(countHider==0){
                countHider = 0;
                NoHiderLeft.SetActive(true);
                PlayerCharacter.GetComponent<Controller>().enabled = false;
                PlayerCamera.GetComponent<MouseLook>().enabled = false;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Destroy(BulletScript.GetComponent<ShootingCharacter>());
            }
            AICharacter.SetActive(false);
            WarningUI.SetActive(false);
        }
        if(other.tag == "Player"){
            //seekerdead
            countSeeker -= 1;
            CountUISeeker.text = countSeeker.ToString("0");
            WarningUI.SetActive(false);
            isDown = true;  
            if(countSeeker == 0){
                countSeeker = 0;
                NoSeekerLeft.SetActive(true);
                PlayerCharacter.GetComponent<Controller>().enabled = false;
                PlayerCamera.GetComponent<MouseLook>().enabled = false;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Destroy(BulletScript.GetComponent<ShootingCharacter>());
            }
            AICharacter.SetActive(false);
            WarningUI.SetActive(false);
        }
        else if(isDown == true){
            WarningUI.SetActive(false);
        }
    }

}