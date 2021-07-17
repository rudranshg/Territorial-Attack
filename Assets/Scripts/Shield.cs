using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Triggered trigger;    //for accessing i variable
    public GameObject Trigger;   //for accessing shield script
    public float shield_timer;
    public float time;

    void Start()
    {
        trigger.i = 0;
        time = shield_timer;
    }

    void Update()
    {
        if(shield_timer<0)
        {
            Debug.Log("hello");
            shield_timer = time;
            Trigger.GetComponent<Shield>().enabled = false;
            return;
        }
        trigger.i = 0;
        shield_timer -= Time.deltaTime;
    }
}
