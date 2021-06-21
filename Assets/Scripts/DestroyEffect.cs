using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{

    //to check collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Destroy();
        }
    }
     
    //destroy game object
    void Destroy()
    {
        Destroy(gameObject);
    }
}
