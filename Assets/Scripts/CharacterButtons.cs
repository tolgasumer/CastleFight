using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour {

    /*public void OnClickBuyCharacter()
    {
        PlayerStats playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        if(playerStats.totalGold >= 50)
        {

        }
    }*/

    // Core character buttons actions 
    public void OnClickCharacterButtons()
    {
        PlayerStats playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log("selectedGameObject:" + selectedGameObject);
        if(selectedGameObject.name == "meleeButton")
        {
            for (int i = 0; i < selectedGameObject.transform.parent.childCount; i++)
            {
                selectedGameObject.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);

            }
            selectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if(selectedGameObject.name == "rangedButton")
            {
                for (int i = 0; i < selectedGameObject.transform.parent.childCount; i++)
                {
                    selectedGameObject.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);

                }
                if(playerStats.unlockedUnits[1] == 0)
                {
                    if (playerStats.totalGold >= 20)
                    {
                        selectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
                        playerStats.unlockedUnits[1] = 1;
                        selectedGameObject.transform.GetChild(1).gameObject.SetActive(false);

                        playerStats.totalGold -= 20;
                    }

                }
                else
                {
                    selectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
                    selectedGameObject.transform.GetChild(1).gameObject.SetActive(false);
                }

            }
            else if (selectedGameObject.name == "mageButton")
            {
                for (int i = 0; i < selectedGameObject.transform.parent.childCount; i++)
                {
                    selectedGameObject.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);

                }
                if (playerStats.unlockedUnits[0] == 0)
                {
                    if (playerStats.totalGold >= 35)
                    {

                        selectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
                        playerStats.unlockedUnits[0] = 1;
                        selectedGameObject.transform.GetChild(1).gameObject.SetActive(false);

                        playerStats.totalGold -= 35;
                    }
                }
                else
                {
                    selectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
                    selectedGameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
                
            }
        }

        /*for (int i = 0; i < selectedGameObject.transform.parent.childCount; i++)
        {
            selectedGameObject.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);

        }
        selectedGameObject.transform.GetChild(0).gameObject.SetActive(true);*/

    }

    //change core character buttons images when character update buttons clicked
    public void OnClickUpgradeButtons()
    {
        PlayerStats playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        SpawnManagerPlayer spawnManagerPlayer = GameObject.Find("spawn_player").GetComponent<SpawnManagerPlayer>();

        GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log("selectedUpgradeButton:" + selectedGameObject);

        if(playerStats.totalGold >= 15)
        {
            if(selectedGameObject.name == "meleeUpgrade1")
            {
                spawnManagerPlayer.elementUpgradesKobold[0] = 1;
                spawnManagerPlayer.elementUpgradesKobold[1] = 0;
                spawnManagerPlayer.elementUpgradesKobold[2] = 0;
                GameObject.Find("MeleeElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/fire1");
            }
            if (selectedGameObject.name == "meleeUpgrade2")
            {
                spawnManagerPlayer.elementUpgradesKobold[0] = 0;
                spawnManagerPlayer.elementUpgradesKobold[1] = 1;
                spawnManagerPlayer.elementUpgradesKobold[2] = 0;
                GameObject.Find("MeleeElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/ice1");
            }
            if (selectedGameObject.name == "meleeUpgrade3")
            {
                spawnManagerPlayer.elementUpgradesKobold[0] = 0;
                spawnManagerPlayer.elementUpgradesKobold[1] = 0;
                spawnManagerPlayer.elementUpgradesKobold[2] = 1;
                GameObject.Find("MeleeElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/nature1");
            }

            if (selectedGameObject.name == "rangedUpgrade1")
            {
                spawnManagerPlayer.elementUpgradesArcher[0] = 1;
                spawnManagerPlayer.elementUpgradesArcher[1] = 0;
                spawnManagerPlayer.elementUpgradesArcher[2] = 0;
                GameObject.Find("RangedElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/fire1");
            }
            if (selectedGameObject.name == "rangedUpgrade2")
            {
                spawnManagerPlayer.elementUpgradesArcher[0] = 0;
                spawnManagerPlayer.elementUpgradesArcher[1] = 1;
                spawnManagerPlayer.elementUpgradesArcher[2] = 0;
                GameObject.Find("RangedElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/ice1");
            }
            if (selectedGameObject.name == "rangedUpgrade3")
            {
                spawnManagerPlayer.elementUpgradesArcher[0] = 0;
                spawnManagerPlayer.elementUpgradesArcher[1] = 0;
                spawnManagerPlayer.elementUpgradesArcher[2] = 1;
                GameObject.Find("RangedElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/nature1");
            }

            if (selectedGameObject.name == "mageUpgrade1")
            {
                spawnManagerPlayer.elementUpgradesWitch[0] = 1;
                spawnManagerPlayer.elementUpgradesWitch[1] = 0;
                spawnManagerPlayer.elementUpgradesWitch[2] = 0;
                GameObject.Find("MageElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/fire1");
            }
            if (selectedGameObject.name == "mageUpgrade3")
            {
                spawnManagerPlayer.elementUpgradesWitch[0] = 0;
                spawnManagerPlayer.elementUpgradesWitch[1] = 1;
                spawnManagerPlayer.elementUpgradesWitch[2] = 0;
                GameObject.Find("MageElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/ice1");
            }
            if (selectedGameObject.name == "mageUpgrade2")
            {
                spawnManagerPlayer.elementUpgradesWitch[0] = 0;
                spawnManagerPlayer.elementUpgradesWitch[1] = 0;
                spawnManagerPlayer.elementUpgradesWitch[2] = 1;
                GameObject.Find("MageElementImageSlot").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/element/nature1");
            }

            selectedGameObject.transform.parent.parent.GetComponent<Image>().sprite = selectedGameObject.GetComponent<Image>().sprite;
            selectedGameObject.transform.parent.gameObject.SetActive(false);

            playerStats.totalGold -= 15;
        }
        /*selectedGameObject.transform.parent.parent.GetComponent<Image>().sprite = selectedGameObject.GetComponent<Image>().sprite;
        selectedGameObject.transform.parent.gameObject.SetActive(false);*/

    }

}
