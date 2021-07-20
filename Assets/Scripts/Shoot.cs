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

    public int count1 = 0;
    public int count2 = 0;
    public int count3 = 0;

    public DisableEnable enable;

    public GameObject HammerSprite;
    public GameObject HammerButton;
    public GameObject Hammer;
    public GameObject hero;
    public GameObject tracer;

    public GameObject healthPotion;

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
        if (enable.active[0] || enable.active[1] || enable.active[2] || HammerSprite.activeSelf)
        {
            pressed_shoot = true;
        }       
    }

    void Update()
    {
        if (pressed_shoot)
        {
            shot = true;
            if (GameObject.Find("Player").GetComponent<DisableEnable>().active[0])
            {
                count1 += 1;
                Shooting(Stone1);

            }
            else if (GameObject.Find("Player").GetComponent<DisableEnable>().active[1])
            {
                count2 += 1;
                Shooting(Stone2);
            }

            else if (GameObject.Find("Player").GetComponent<DisableEnable>().active[2])
            {
                count3 += 1;
                Shooting(Stone3);
            }
            else if (HammerSprite.activeSelf) Shooting(Hammer);
            bow.tracer = false;
        }
    }

    void Shooting(GameObject other)
    {
        healthPotion.GetComponent<AudioSource>().volume = 0f;
        m_Animator.SetBool("HasShot", shot);
        if (other.gameObject == Hammer)
        {
            HammerButton.GetComponent<AudioSource>().volume = 0f;
            GameObject Stoneclone = Instantiate(other, HammerSprite.transform.position, HammerSprite.transform.rotation);
            Stoneclone.GetComponent<Rotation>().rotation = true;
            Stoneclone.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
            //HammerButton.SetActive(false);
            //HammerButton.SetActive(true);
        }
        else
        {
            GameObject Stoneclone = Instantiate(other, transform.position, transform.rotation);
            Stoneclone.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        }
        HammerSprite.SetActive(false);
        shot = false;
        m_Animator.SetBool("HasShot", shot);
        pressed_shoot = false;
        shoot.SetActive(false);
        shoot.SetActive(true);
        tracer.SetActive(false);
        tracer.SetActive(true);
    }
}