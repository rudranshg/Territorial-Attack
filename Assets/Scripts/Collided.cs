using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collided : MonoBehaviour
{
    public int i = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            i = 1;
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            i = 2;
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            i = 3;
        }
    }

    

}
