using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public GameObject youWonImage;
    public GameObject youLostImage;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        Application.LoadLevel("SampleScene");
    }
    public void YouWon()
    {
        Time.timeScale = 0;
        youWonImage.SetActive(true);
        
    }
    public void YouLost()
    {
        Time.timeScale = 0;
        youLostImage.SetActive(true);

    }
}
