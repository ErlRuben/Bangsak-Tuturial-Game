using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BangsakDamageSeeker : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject AISeeker;
    public GameObject StickDisable;
    public Text CountUI;
    public float countHider = 0;
    public GameObject NoHiderLeft;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        AISeeker.GetComponent<BangsakHider>().enabled = true;
    }
    void Update(){
        float f1 = float.Parse(CountUI.text);
        countHider = f1;

    }
    public void OnTriggerEnter(Collider other) {
        if(other.tag == "EnemyBullet"){
            countHider -= 1;
            CountUI.text = countHider.ToString("0");
            
            Cursor.lockState = CursorLockMode.None;
            AISeeker.SetActive(false);
            StickDisable.SetActive(false);
            if(countHider == 0){
                countHider = 0;
                Cursor.lockState = CursorLockMode.None;
                PlayerCharacter.GetComponent<Controller>().enabled = false;
                PlayerCamera.GetComponent<MouseLook>().enabled = false;
            }
        }

    }
}
