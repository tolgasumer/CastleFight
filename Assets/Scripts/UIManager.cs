using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public TMP_Text goldText;

    PlayerStats playerStats;

    // Use this for initialization
    void Start () {
        goldText = GameObject.Find("GoldText").GetComponent<TMP_Text>();

        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
        goldText.text = playerStats.totalGold.ToString();
	}

}
