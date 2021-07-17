using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    public GameObject[] projectile;
    public GameObject character;

    public Transform launchsite;

    public float flag = 0;
    float countdown;
    float random;

    public float delay = 0f;
    public float range;
    public float time = 1f;
    public float gravityy = 5f;
    public float height;

    float velocityX;
    float velocityY;


    int a;
    int[] table = { 33, 33, 34 };

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3"||collision.gameObject.tag=="Hammer")
        {
            flag = 1;
        }
    }
    void Start()
    {
        countdown = delay;

    }

    // Update is called once per frame
    void Update()

    {
        if (flag == 1)
        {
            random = Random.Range(0, 100);      //selcting random number 
            for (int i = 0; i < 3; i++)
            {                                   //selecting projectile to throw 
                if (random < table[i])
                {
                    a = i;
                    break;
                }
                else
                {
                    random -= table[i];
                }
            }
        }
        if (flag == 1)
        {
            countdown -= Time.deltaTime;
        }
        if (flag == 1 && countdown < 0f)
        {
            Fire(projectile[a]);
            countdown = delay;
        }
        range = launchsite.transform.position.x - character.transform.position.x;
        range = Random.Range(range-2,range+2);
        height = character.transform.position.y - launchsite.transform.position.y;
        velocityX = (range) / time;
        velocityY = (2 * height + gravityy * 10 * time * time) / (2 * time);
    }
    void Fire(GameObject weapon)
    {
        GameObject attackerinst = Instantiate(weapon, launchsite.position, Quaternion.identity);
        attackerinst.GetComponent<Rotation>().rotation = true;
        attackerinst.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        attackerinst.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX, velocityY);

    }
}