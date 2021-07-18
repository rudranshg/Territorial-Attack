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

    public DisableEnable enable;

    public GameObject HammerSprite;
    public GameObject HammerButton;
    public GameObject Hammer;
    public GameObject hero;
    public GameObject tracer;

    public GameObject shoot;
    public bool pressed_shoot = false;
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

    public void shoot_press(){
        if (enable.appears1 || enable.appears2 || enable.appears3 || HammerSprite.activeSelf)
        {
            pressed_shoot = true;
        }       
    }

    void Update()
    {
        if (pressed_shoot)
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
            else if (HammerSprite.activeSelf) Shooting(Hammer);
            bow.tracer = false;
        }
    }

    void Shooting(GameObject other)
    {
        m_Animator.SetBool("HasShot", shot);
        if (other.gameObject == Hammer)
        {
            GameObject Stoneclone = Instantiate(other, HammerSprite.transform.position, HammerSprite.transform.rotation);
            Stoneclone.GetComponent<Rotation>().rotation = true;
            Stoneclone.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        }
        else
        {
            GameObject Stoneclone = Instantiate(other, transform.position, transform.rotation);
            Stoneclone.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        }        
        
        GameObject.Find("Player").GetComponent<DisableEnable>().Disappear();
        HammerSprite.SetActive(false);
        shot = false;
        m_Animator.SetBool("HasShot", shot);
        pressed_shoot = false;
        shoot.SetActive(false);
        shoot.SetActive(true);
        HammerButton.SetActive(false);
        HammerButton.SetActive(true);
        tracer.SetActive(false);
        tracer.SetActive(true);
    }
}