using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collided : MonoBehaviour
{
    public int i = 0;
    public float HitCount = 0f;
    public ParticleSystem enemythunder;
    public PowerupController Costs;
    //public EnemyMovement movement;
    public void HP_click(){
        HitCount -= Costs.HP_cost;
    }

    public void H_click(){
        HitCount -= Costs.H_cost;
    }

    public void S_click(){
        HitCount -= Costs.S_cost;
    }

    public void L_click(){
        HitCount -= Costs.L_cost;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            i = 1;
        }
        else if (collision.gameObject.tag == "Enemy2")
        {
            i = 2;
        }
        else if (collision.gameObject.tag == "Enemy3")
        {
            i = 3;
        }
        else if (collision.gameObject.tag == "Hammer")
        {
            enemythunder.Play();
            i = 7;
        }

        if (i!=0)HitCount++;
        //movement.speed += (float)(HitCount /20);
    }

}
