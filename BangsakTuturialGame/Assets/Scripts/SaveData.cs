using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveData : MonoBehaviour
{
    public float NumberFinished = 0;
    //myObject.GetComponent<MyScript>().MyFunction();
    // Update is called once per frame
    public void Update(){
        NumberFinished = PlayerPrefs.GetFloat("SaveWork");
        if(NumberFinished == 5){
            NumberFinished = 0;
            PlayerPrefs.SetFloat("SaveWork", NumberFinished);
            Debug.Log("Total Finished: " + NumberFinished);
            SceneManager.LoadScene("EndGame");
        }
    }
    public void DoneGames(){
        NumberFinished += 1;
        PlayerPrefs.SetFloat("SaveWork", NumberFinished);
    }
    
}

