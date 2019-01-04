using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarBillboard : MonoBehaviour {
    Camera m_Camera;
    //private Image image;
    //Stats stats;

    void Start()
    {
        m_Camera = Camera.main;
        //stats = GetComponentInParent<Stats>();
        //image = GetComponent<Image>();
    }

    void Update()
    {
        //olunce hpbari kapat
        /*if(!stats.isAlive)
        {
            image.enabled = false;
        }*/
        
    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
