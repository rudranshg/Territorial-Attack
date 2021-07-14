using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupController : MonoBehaviour
{
    //Defining powerups
    public GameObject healthPotion;
    public GameObject hammer;
    public GameObject shield;
    public GameObject tracer;

    //Defining counter variables
    public int count1;
    public int count2;
    public int count3;
    public int count4;
    public int hit;

    public Player player;

     void Start()
    {
        hit = player.Hits;
        healthPotion.GetComponent<Button>().interactable = true;
        hammer.GetComponent<Button>().interactable = true;
        shield.GetComponent<Button>().interactable = true;
        tracer.GetComponent<Button>().interactable = true;
    }

    void Update()
    {
        hit = player.Hits;

        //Activating buttons at desired hits
        if (hit >= count1) healthPotion.GetComponent<Button>().interactable=true;
        if (hit >= count2) hammer.GetComponent<Button>().interactable = true;
        if (hit >= count3) shield.GetComponent<Button>().interactable = true;
        if (hit >= count4) tracer.GetComponent<Button>().interactable = true;

        ////Deactivating buttons at desired hits
        if (hit < count1) healthPotion.GetComponent<Button>().interactable = false;
        if (hit < count2) hammer.GetComponent<Button>().interactable = false;
        if (hit < count3) shield.GetComponent<Button>().interactable = false;
        if (hit < count4) tracer.GetComponent<Button>().interactable = false;
    }

    
}
