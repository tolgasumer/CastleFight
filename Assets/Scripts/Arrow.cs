using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    GameObject target;
    bool isLaunched;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(target.GetComponent<Stats>().isAlive)
        {
            float step = 20f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y + 0.5f, target.transform.position.z), step);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

    public void LaunchArrow(GameObject arrowTarget)
    {
        target = arrowTarget;
        isLaunched = true;
    }
}
