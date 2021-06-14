using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == true)
        {
            TraceMovement();
        }
    }
    void TraceMovement()
    {
        Vector2 direction = rb.velocity;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnCollisionEnter2D(Collision2D collide)
    {
        hasHit = false;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
