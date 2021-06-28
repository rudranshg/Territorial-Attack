using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collided : MonoBehaviour
{
    public int i = 0;
    public int HitCount = 0;
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
            i = 7;
        }

        if (i!=0)HitCount++;
    }

}
