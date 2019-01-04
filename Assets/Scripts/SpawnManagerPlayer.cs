using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManagerPlayer : MonoBehaviour {

    GameObject kobold;
    GameObject witch;
    GameObject archer;

    GameObject clone;

    // fire, ice, nature
    public int[] elementUpgradesKobold = { 0, 0, 0 };

    // fire, ice, nature
    public int[] elementUpgradesWitch = { 0, 0, 0 };

    // fire, ice, nature
    public int[] elementUpgradesArcher = { 0, 0, 0 };

    // Use this for initialization
    void Start()
    {
        kobold = Resources.Load("Prefabs/Units/kobold", (typeof(GameObject))) as GameObject;
        witch = Resources.Load("Prefabs/Units/witch", (typeof(GameObject))) as GameObject;
        archer = Resources.Load("Prefabs/Units/archer", (typeof(GameObject))) as GameObject;


        //InvokeRepeating("spawnWitch", 2.5f, 15.5f);
        //InvokeRepeating("spawnArcher", 3.0f, 16.0f);
        InvokeRepeating("spawnUnits", 0f, 13f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnKobold()
    {
        clone = Instantiate(kobold, transform.position, transform.rotation);
        clone.tag = "Player";
        clone.transform.GetChild(4).tag = "HitboxPlayer";

        //eger upgrade yapilmissa
        if (elementUpgradesKobold[0] + elementUpgradesKobold[1] + elementUpgradesKobold[2] > 0)
        {
            if (elementUpgradesKobold[0] == 1)
            {
                clone.gameObject.GetComponent<Stats>().fireUpgrade = 1;
            }
            else if (elementUpgradesKobold[1] == 1)
            {
                clone.gameObject.GetComponent<Stats>().iceUpgrade = 1;
            }
            else if (elementUpgradesKobold[2] == 1)
            {
                clone.gameObject.GetComponent<Stats>().natureUpgrade = 1;
            }
        }

    }
    void spawnWitch()
    {
        clone = Instantiate(witch, transform.position, transform.rotation);
        clone.tag = "Player";
        clone.transform.GetChild(3).tag = "HitboxPlayer";

        //eger upgrade yapilmissa
        if (elementUpgradesWitch[0] + elementUpgradesWitch[1] + elementUpgradesWitch[2] > 0)
        {
            if (elementUpgradesWitch[0] == 1)
            {
                clone.gameObject.GetComponent<Stats>().fireUpgrade = 1;
            }
            else if (elementUpgradesWitch[1] == 1)
            {
                clone.gameObject.GetComponent<Stats>().iceUpgrade = 1;
            }
            else if (elementUpgradesWitch[2] == 1)
            {
                clone.gameObject.GetComponent<Stats>().natureUpgrade = 1;
            }
        }
    }
    void spawnArcher()
    {
        clone = Instantiate(archer, transform.position, transform.rotation);
        clone.tag = "Player";
        clone.transform.GetChild(3).tag = "HitboxPlayer";

        //eger upgrade yapilmissa
        if (elementUpgradesArcher[0] + elementUpgradesArcher[1] + elementUpgradesArcher[2] > 0)
        {
            if (elementUpgradesArcher[0] == 1)
            {
                clone.gameObject.GetComponent<Stats>().fireUpgrade = 1;
            }
            else if (elementUpgradesArcher[1] == 1)
            {
                clone.gameObject.GetComponent<Stats>().iceUpgrade = 1;
            }
            else if (elementUpgradesArcher[2] == 1)
            {
                clone.gameObject.GetComponent<Stats>().natureUpgrade = 1;
            }
        }
    }

    void spawnUnits()
    {
        PlayerStats playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();

        Invoke("spawnKobold", 2.0f);

        if (playerStats.unlockedUnits[0] == 1)
        {
            Invoke("spawnWitch", 3f);
        }
        if (playerStats.unlockedUnits[1] == 1)
        {
            Invoke("spawnArcher", 4f);
        }
    }
}
