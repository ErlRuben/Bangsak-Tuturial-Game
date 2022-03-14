using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Slider MainVolumeSlider;
    public AudioSource ClickSFX;
    public AudioClip ClickFx;
    void Start(){
        if(!PlayerPrefs.HasKey("Main")){
            PlayerPrefs.SetFloat("Main", 1);
            Load();
        }
        else{
            Load();
        }
    }
    public void StartGame(){
        //When Pressed Start
        SceneManager.LoadScene("TutorialMode");
        Time.timeScale = 1f;
    }
    public void ExitGame(){
        //When Pressed Quit
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void VolumeChange(){
        //When Pressed Confirm Settings, Saved
        AudioListener.volume = MainVolumeSlider.value;
        Save();
    }
    private void Load(){
        //Load Slider Value
        MainVolumeSlider.value = PlayerPrefs.GetFloat("Main");
    }
    private void Save(){
        //Save Slider Value
        PlayerPrefs.SetFloat("Main", MainVolumeSlider.value);
    }
    public void ClickSound(){
        ClickSFX.PlayOneShot(ClickFx);
    }
    public void ReturnMenu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void DoneTutorial(){
        SceneManager.LoadScene("Bangsak");
        Time.timeScale = 1f;
    }
    public void DoneBangsak(){
        SceneManager.LoadScene("Patintero");
    }
    public void EndGame(){
        SceneManager.LoadScene("EndGame");
    }
}
