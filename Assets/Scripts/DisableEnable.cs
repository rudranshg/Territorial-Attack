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

    /*public void EnableSlider()
    {
        if(activated)
        {
            volume.SetActive(false);
            activated = false;
        }
        else
        {
            volume.SetActive(true);
            activated = true;
        }
    }*/

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
        /*if (!active[2])   //check if object2 is already present
        {
            if (!appears3)  //check if object3 is already present
            {
                Object1.SetActive(true);
                appears1 = true;
            }
            else
            {
                Object3.SetActive(false);
                appears3 = false;
                Object1.SetActive(true);
                appears1 = true;
            }
        }*/
        //if (!appears1)   //check if object1 is already present
        //{
        /*else
          {
              Object2.SetActive(false);
              appears2 = false;
              if (!appears3)  
              {
                  Object1.SetActive(true);
                  appears1 = true;
              }
              else
              {
                  Object3.SetActive(false);
                  appears3 = false;
                  Object1.SetActive(true);
                  appears1 = true;
              }
          }
      }
      else
      {
          Object1.SetActive(false);
          appears1 = false;
          if (!appears2)   
          {
              if (appears3)  
              {
                  Object3.SetActive(false);
                  appears3 = false;
              }             
           }
          else
          {
              Object2.SetActive(false);
              appears2 = false;
              if (appears3)  
              {
                  Object3.SetActive(false);
                  appears3 = false;
              }

          }*/
        //}
    }

    public void Inactive2()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 1);
        /*if (!appears1)   //check if object2 is already present
        {
            if (!appears3)  //check if object3 is already present
            {
                Object2.SetActive(true);
                appears2 = true;
            }
            else
            {
                Object3.SetActive(false);
                appears3 = false;
                Object2.SetActive(true);
                appears2 = true;
            }
        }*/
        /*if (!appears2)   //check if object1 is already present
        {
            else
            {
                Object1.SetActive(false);
                appears1 = false;
                if (!appears3)
                {
                    Object2.SetActive(true);
                    appears2 = true;
                }
                else
                {
                    Object3.SetActive(false);
                    appears3 = false;
                    Object2.SetActive(true);
                    appears2 = true;
                }
            }
        }
        else
        {
            Object2.SetActive(false);
            appears2 = false;
            if (!appears1)
            {
                if (appears3)
                {
                    Object3.SetActive(false);
                    appears3 = false;
                }
            }
            else
            {
                Object1.SetActive(false);
                appears1 = false;
                if (appears3)
                {
                    Object3.SetActive(false);
                    appears3 = false;
                }

            }
        }*/
    }


    public void Inactive3()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 2);
        /*if (!appears2)   //check if object2 is already present
            {
                if (!appears1)  //check if object3 is already present
                {
                    Object3.SetActive(true);
                    appears3 = true;
                }
                else
                {
                    Object1.SetActive(false);
                    appears1 = false;
                    Object3.SetActive(true);
                    appears3 = true;
                }
            }*/
        /*if (!appears3)   //check if object1 is already present
        {
            
            else
            {
                Object2.SetActive(false);
                appears2 = false;
                if (!appears1)
                {
                    Object3.SetActive(true);
                    appears3 = true;
                }
                else
                {
                    Object1.SetActive(false);
                    appears1 = false;
                    Object3.SetActive(true);
                    appears3 = true;
                }
            }
        }
        else
        {
            Object3.SetActive(false);
            appears3 = false;
            if (!appears2)
            {
                if (appears1)
                {
                    Object1.SetActive(false);
                    appears1 = false;
                }
            }
            else
            {
                Object2.SetActive(false);
                appears2 = false;
                if (appears1)
                {
                    Object1.SetActive(false);
                    appears1 = false;
                }
            }
        }*/
    }
}
