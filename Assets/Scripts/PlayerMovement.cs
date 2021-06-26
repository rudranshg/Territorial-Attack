using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 100f;

	Vector3 move;

	Animator m_Animator;

    public bool isWalking=false;
    public bool jump = false;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    } 

	void FixedUpdate()
	{
        float moved = Input.GetAxis("Horizontal");
        if (moved!=0)
        {
            isWalking = true;
        }
        move.x = Input.GetAxis("Horizontal");

        transform.Translate(move * Time.fixedDeltaTime * speed);
        m_Animator.SetBool("IsWalking", isWalking);
        isWalking = false;
    }
}
