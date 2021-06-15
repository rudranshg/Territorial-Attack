using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject Stone;
    private float LaunchForce;
    // Start is called before the first frame update
    // Update is called once per frame
    public void AdjustForce(float newforce)
    {
        LaunchForce = newforce;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shooting();
        }
    }

     void Shooting()
    {
        GameObject Stoneclone = Instantiate(Stone, transform.position, transform.rotation);

        Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
    }
}
