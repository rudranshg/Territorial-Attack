using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnable : MonoBehaviour
{
    //the n number of objects which we want to shoot
    public GameObject[] Projectile;
    //public GameObject volume;
    public GameObject HammerButton;
    public int ball=3;
    public int shoe=2;
    public int stone=2;

    public Shoot shoot;

    public bool activated=false;


    //the bools corresponding to each object depicting it's appearence/disappearence
    public bool[] active;

    public GameObject TennisBall;
    public GameObject stones;
    public GameObject shoes;
    //disappearing each object in starting
    private void Start()
    {
        for(int i=0;i<3;i++)
        {
            Projectile[i].SetActive(false);
        }

    }

    public void Disappear(bool activated,int i)
    {
        for(int k=0;k<3;k++)
        {
            Projectile[k].SetActive(false);
            active[k] = false;
        }
        Projectile[i].SetActive(activated);
        active[i] = activated;
    }

    public void Update()
    {
        if (shoot.count1 == ball)
        {
            TennisBall.SetActive(false);
            Projectile[0].SetActive(false);
            active[0] = false;
        }
        if (shoot.count2 == shoe)
        {
            shoes.SetActive(false);
            Projectile[1].SetActive(false);
            active[1] = false;
        }
        if (shoot.count3 == stone)
        {
            stones.SetActive(false);
            Projectile[2].SetActive(false);
            active[2] = false;
        }

    }
    public void Inactive1()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 0);
    }

    public void Inactive2()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 1);
    }


    public void Inactive3()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 2);
    }
}
