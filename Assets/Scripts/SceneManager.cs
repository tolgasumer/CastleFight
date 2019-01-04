using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour {
    public GameObject startScreen;
    public GameObject menuScreen;
    public GameObject upgradeBar;

    public Sprite SoundOnIMG;
    public Sprite SoundOffIMG;

    public bool soundChecker;
	// Use this for initialization
	void Start () {

        Time.timeScale = 0;
        soundChecker = true;

    }
	
    public void OnClickStartButton()
    {
        Time.timeScale = 1;
        startScreen.SetActive(true);
        upgradeBar.SetActive(true);
        menuScreen.SetActive(false);

    }

    public void OnClickExitButton()
    {
        Application.Quit();
        Debug.Log("exit button clicked");
    }

    public void OnClickSoundButton()
    {
        GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;

        if (soundChecker)
        {
            AudioListener.pause = true;
            selectedGameObject.transform.GetComponent<Image>().sprite = SoundOffIMG;
            soundChecker = false;
            Debug.Log("sound off");

        }
        else if (!soundChecker)
        {
            AudioListener.pause = false;
            selectedGameObject.transform.GetComponent<Image>().sprite = SoundOnIMG;
            soundChecker = true;
            Debug.Log("sound on");



        }
    }


}
