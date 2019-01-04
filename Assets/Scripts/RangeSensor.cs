using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if((transform.parent.tag == "Player" && other.tag == "HitboxBot") || (transform.parent.tag == "Bot" && other.tag == "HitboxPlayer"))
        {
            //karsi colliderin parent'i canli ise
            if(other.gameObject.transform.parent.gameObject.GetComponent<Stats>().isAlive)
            {
                SendMessageUpwards("Attack", other.gameObject.transform.parent.gameObject);
            }
        }
    }
}
