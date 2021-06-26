using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 100f;

    Vector3 move;

    Animator m_Animator;

    public Enemy enemy;

    public bool isWalking = false;
    public bool jump = false;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(enemy.isHit)
        {
            isWalking = true;
            move.x = -1;
        }
        transform.Translate(move * Time.fixedDeltaTime * speed);
        m_Animator.SetBool("IsWalking", isWalking);
        isWalking = false;
    }
}
