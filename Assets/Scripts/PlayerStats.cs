using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	int staticGoldIncome = 5;
    public float totalGold;
    public int[] unlockedUnits = {0, 0};
	// Use this for initialization
	void Start () {
        //unlockedUnits[0] = 1;
        totalGold = 50;
		InvokeRepeating ("GoldIncome", 5f, 5f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
	void GoldIncome () {
		totalGold += staticGoldIncome;
		
	}
}
