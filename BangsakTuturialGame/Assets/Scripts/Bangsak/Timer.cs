using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    [SerializeField] Text countdowntext;
    public GameObject DoneTimeSeeker;
    public GameObject PlayerCharacter;
    public GameObject PlayerCamera;
    public GameObject BulletScript;
    public Text CountUI;
    public float countTimer = 1;
    public Text CountUISeek;
    public float countTimerSeek = 1;
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
                Destroy(BulletScript.GetComponent<ShootingCharacter>());
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}
