using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 100f;

    float t = 0;

    Vector3 move;

    Animator m_Animator;

    public bool isWalking = false;

    public Enemy enemy;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (enemy.isHit)
        {
            t = -1;
        }
        move.x = t;
        if (move.x != 0) isWalking = true;
        transform.Translate(move * Time.fixedDeltaTime * speed);
        m_Animator.SetBool("IsWalking", isWalking);
        if (move.x != 0) isWalking = true;    }
}
