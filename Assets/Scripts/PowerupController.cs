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
    public int HP_cost;
    public int H_cost;
    public int S_cost;
    public int L_cost;
    public int hit;

    public Player player;
    
     void Start()
    {
        hit = player.Hits;
        healthPotion.GetComponent<Button>().interactable = false;
        hammer.GetComponent<Button>().interactable = false;
        shield.GetComponent<Button>().interactable = false;
        tracer.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        hit = player.Hits;

        //Activating buttons at desired hits
        if (hit >= HP_cost) healthPotion.GetComponent<Button>().interactable=true;
        if (hit >= H_cost) hammer.GetComponent<Button>().interactable = true;
        if (hit >= S_cost) shield.GetComponent<Button>().interactable = true;
        if (hit >= L_cost) tracer.GetComponent<Button>().interactable = true;

        ////Deactivating buttons at desired hits
        if (hit < HP_cost) healthPotion.GetComponent<Button>().interactable = false;
        if (hit < H_cost) hammer.GetComponent<Button>().interactable = false;
        if (hit < S_cost) shield.GetComponent<Button>().interactable = false;
        if (hit < L_cost) tracer.GetComponent<Button>().interactable = false;
    }

    
}
