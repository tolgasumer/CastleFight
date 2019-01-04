using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float maxHp;
    public float currentHp;
    public float damage;
    public float defaultSpeed;
    public float currentSpeed;
    public float attackWaitTime; //kac saniyede bir atak yapacagi
    public float lastAttackTime; //son atak zamani, cooldown icin
    public float goldValue;
    public bool isAlive;
    public bool isAttacking;

    //element
    public float fireUpgrade;
    public float iceUpgrade;
    public float natureUpgrade;

    Collider[] childColliders;

    PlayerStats playerStats;

    public float timeForLerp;

    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
        damage = 1;
        defaultSpeed = 1;
        attackWaitTime = 1.5f;
        lastAttackTime = attackWaitTime; //dogdugu anda saldirabilsin
        isAlive = true;


        switch (gameObject.name)
        {
            case "kobold(Clone)":
                attackWaitTime = 0.4f;
                maxHp = 10;
                currentHp = maxHp;
                //damage = 1;
                //attackWaitTime = 0.533f;
                //fireUpgrade = 1; //test
                break;
            case "witch(Clone)":
                attackWaitTime = 0.7f;
                maxHp = 8;
                currentHp = maxHp;
                //damage = 2;
                //attackWaitTime = 1f;
                //iceUpgrade = 1; //test
                break;
            case "archer(Clone)":
                attackWaitTime = 0.75f;
                maxHp = 6;
                currentHp = maxHp;
                //damage = 3;
                //attackWaitTime = 1.133f;
                //natureUpgrade = 1; //test
                break;
            case "castle_bot":
                maxHp = 20;
                currentHp = maxHp;
                Debug.Log("castle_bot hp ayarlandi");
                break;
            case "castle_player":
                maxHp = 20;
                currentHp = maxHp;
                Debug.Log("castle_player hp ayarlandi");
                break;
        }

        //olunce verecegi goldu bulmak icin
        if (gameObject.CompareTag("Bot"))
        {
            if(gameObject.name == "kobold(Clone)")
            {
                goldValue = 5f;
            }
            if (gameObject.name == "witch(Clone)")
            {
                goldValue = 9f;
            }
            if (gameObject.name == "archer(Clone)")
            {
                goldValue = 14f;
            }
        }
        else
        {
            goldValue = 0;
        }

        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Die();
        }
        if (isAttacking)
        {
            currentSpeed = 0;
        }

        /*if (lastAttackTime < attackWaitTime)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }*/
    }

    private void FixedUpdate()
    {
        if(isAttacking)
        {
            lastAttackTime += Time.deltaTime;

        }
        else
        {
            lastAttackTime = 0;
        }
        
    }

    void receiveDamage(float DamageTaken)
    {
        timeForLerp = 0f;
        StartCoroutine(HPBarLerp(currentHp, currentHp - DamageTaken));
        currentHp = currentHp - DamageTaken;

    }

    void Die()
    {
        //bu if olmazsa oldukten sonra her frame gold verme bug i oluyor
        if(isAlive)
        {
            playerStats.totalGold += goldValue;
        }
        isAlive = false;
        currentSpeed = 0;

        if(gameObject.name == "castle_player")
        {
            Debug.Log("castle_player vefat");
            GameObject.Find("GameManager").GetComponent<LevelLoader>().YouLost();
        }
        if (gameObject.name == "castle_bot")
        {
            Debug.Log("castle_bot vefat");
            GameObject.Find("GameManager").GetComponent<LevelLoader>().YouWon();
        }


        //oldukten sonra colliderlari kapat
        DestroyChildColliders();
        Destroy(gameObject, 3f); //oldukten 3saniye sonra obje silinsin

    }

    // bunlari eskiden kullaniyoduk su an gerek yok ama bulunsun

    public void DestroyChildColliders()
    {
        childColliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in childColliders)
        {
            col.enabled = false;
        }
    }

    IEnumerator HPBarLerp(float oldHp, float newHp)
    {
        while(timeForLerp < 1f)
        {
            timeForLerp += Time.deltaTime*6f;
            /*if(gameObject.transform.Find("HPBarCanvas/Slider/Fill Area/Fill").gameObject.GetComponent<Image>() != null)
            {
                gameObject.transform.Find("HPBarCanvas/Slider/Fill Area/Fill").gameObject.GetComponent<Image>().fillAmount = Mathf.Lerp(oldHp / maxHp, newHp / maxHp, timeForLerp);
            }*/
            try
            {
                gameObject.transform.Find("HPBarCanvas/Slider/Fill Area/Fill").gameObject.GetComponent<Image>().fillAmount = Mathf.Lerp(oldHp / maxHp, newHp / maxHp, timeForLerp);
            }
            catch (Exception e)
            {

            }
            //Debug.Log(timeForLerp);
            yield return null;
        }
        
    }

}
