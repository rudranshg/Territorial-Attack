using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 100f;

    float t = 0;

    public GameObject Stationary;
    public GameObject Enemy;

    Vector3 move;

    public bool isWalking;

    Animator m_Animator;

    public Enemy enemy;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        Stationary.transform.position = Enemy.transform.position;
        Stationary.transform.rotation = Enemy.transform.rotation;
    }

    void FixedUpdate()
    {
        t = -1;
        isWalking = !Mathf.Approximately(t, 0f);
        m_Animator.SetBool("IsWalking", isWalking);
        move.x = t;
        transform.Translate(move * Time.fixedDeltaTime * speed); 
    }
}
