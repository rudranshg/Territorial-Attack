using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyProjectile : MonoBehaviour
{

    //to check collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Target")|| collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Hammer"))
        {
            Destroy();
        }
    }
     
    //destroy game object
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
