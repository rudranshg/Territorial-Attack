using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool rotation=false;
    public float speed = 1f;

    void Update()
    {
        if(rotation)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
    }
}
