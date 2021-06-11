using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Stone;
    public float LaunchForce=1000f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0) LaunchForce *= 2;
        else if (Input.GetAxis("Vertical") < 0) LaunchForce /= 2;
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
        LaunchForce = 1000;
    }

     void Shooting()
    {
        GameObject Stoneclone = Instantiate(Stone, transform.position, transform.rotation);

        Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
    }
}
