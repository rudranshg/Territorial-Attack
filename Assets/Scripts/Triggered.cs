using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    public int i = 0;
    public GameObject trigger;
    //public float shield_timer = 10f;

    void Start()
    {
        trigger.GetComponent<Shield>().enabled = false;        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
        {
            //Debug.Log("Ha");
            i = 1;
        }
    }

    public void Shield()
    {
        trigger.GetComponent<Shield>().enabled = true;
    }
}