using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Bow bow;
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Stone3;
    public GameObject hero;

    public float LaunchForce;

    public bool shot = false;

    Animator m_Animator;

    private void Start()
    {
        m_Animator = GameObject.Find("Player").GetComponent<Animator>();
    }
    // Update is called once per frame
    public void AdjustForce(float newforce)
    {
        LaunchForce = newforce;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            shot = true;
            if (GameObject.Find("Player").GetComponent<DisableEnable>().appears1)
            {
                Shooting(Stone1);

            }
            else if (GameObject.Find("Player").GetComponent<DisableEnable>().appears2)
            {
                Shooting(Stone2);
            }

            else if (GameObject.Find("Player").GetComponent<DisableEnable>().appears3)
            {
                Shooting(Stone3);
            }
            shot = false;
            bow.numberOfPoints=5;
        }
    }

    void Shooting(GameObject other)
    {
        m_Animator.SetBool("HasShot", shot);
        GameObject Stoneclone = Instantiate(other, transform.position, transform.rotation);
        Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        GameObject.Find("Player").GetComponent<DisableEnable>().Disappear();
        shot = false;
        m_Animator.SetBool("HasShot", shot);
    }
}