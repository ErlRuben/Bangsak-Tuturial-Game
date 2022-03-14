using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer1 : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 120f;
    [SerializeField] Text countdowntext;
    public GameObject DoneTimeSeeker;
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject PlayerCharacter1;
    public GameObject PlayerCamera1;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdowntext.text = currentTime.ToString("0");
        if(currentTime <= 0){
            currentTime = 0;
            if(currentTime == 0){
                //Tie
                DoneTimeSeeker.SetActive(true);
                Destroy(PlayerCharacter.GetComponent<Controller>());
                Destroy(PlayerCamera.GetComponent<MouseLook>());
                Destroy(PlayerCharacter1.GetComponent<Controller>());
                Destroy(PlayerCamera1.GetComponent<MouseLook>());
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}
