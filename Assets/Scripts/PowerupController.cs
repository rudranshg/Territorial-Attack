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
        healthPotion.SetActive(false);
        hammer.SetActive(false);
        shield.SetActive(false);
        tracer.SetActive(false);
    }

    void Update()
    {
        hit = player.Hits;

        //Activating buttons at desired hits
        if (hit >= HP_cost) healthPotion.SetActive(true);
        if (hit >= H_cost) hammer.SetActive(true);
        if (hit >= S_cost) shield.SetActive(true);
            if (hit >= L_cost) tracer.SetActive(true);
        ////Deactivating buttons at desired hits
        if (hit < HP_cost) healthPotion.SetActive(false);
        if (hit < H_cost) hammer.SetActive(false);
        if (hit < S_cost) shield.SetActive(false);
        if (hit < L_cost) tracer.SetActive(false);
    }

    
}
