using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 100f;

    float t = 0;

    Vector3 move;

    public bool isWalking;

    Animator m_Animator;

    public Enemy enemy;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (enemy.isHit)
        {
            t = -1f;
        }
        isWalking = !Mathf.Approximately(t, 0f);
        m_Animator.SetBool("IsWalking", isWalking);
        move.x = t;
        transform.Translate(move * Time.fixedDeltaTime * speed); 
    }
}
