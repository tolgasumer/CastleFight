using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour {

    public Image hpbar;
    Stats stats;

    // Use this for initialization
    void Start () {
        hpbar = GetComponent<Image>();
        stats = transform.root.GetComponent<Stats>();

        Sprite green = Resources.Load<Sprite>("Sprites/hpbar/GreenBar");
        Sprite red = Resources.Load<Sprite>("Sprites/hpbar/RedBar");

        //element sprites
        Sprite fire1 = Resources.Load<Sprite>("Sprites/element/fire1");
        Sprite ice1 = Resources.Load<Sprite>("Sprites/element/ice1");
        Sprite nature1 = Resources.Load<Sprite>("Sprites/element/nature1");

        //hpbar renkleri
        if (gameObject.transform.root.tag == "Player")
        {
            hpbar.sprite = green;
        }
        else
        {
            hpbar.sprite = red;
        }

        //element image
        if(stats.fireUpgrade == 1)
        {
            gameObject.transform.parent.parent.parent.Find("ElementImage").GetComponent<Image>().sprite = fire1;
        }
        else if (stats.iceUpgrade == 1)
        {
            gameObject.transform.parent.parent.parent.Find("ElementImage").GetComponent<Image>().sprite = ice1;
        }
        else if (stats.natureUpgrade == 1)
        {
            gameObject.transform.parent.parent.parent.Find("ElementImage").GetComponent<Image>().sprite = nature1;
        }
        else
        {
            gameObject.transform.parent.parent.parent.Find("ElementImage").GetComponent<Image>().enabled = false;
        }

        //hpbar initialize
        hpbar.fillAmount = stats.currentHp / stats.maxHp;

    }

	// Update is called once per frame
	void Update () {
        //ARTIK HPBAR FILLAMOUNT RECEIVEDAMAGE DAN DEGISTIRILIYOR
        //hpbar.fillAmount = stats.currentHp/stats.maxHp;

        //olunce hpbar sil
        if(stats.currentHp <= 0)
        {
            //Debug.Log(transform.parent.parent.parent.gameObject);
            Destroy(gameObject.transform.parent.parent.parent.gameObject);
        }
	}
}
