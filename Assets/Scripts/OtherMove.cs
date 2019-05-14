using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMove : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public bool isRigidbody = false;
    private Rigidbody rb;
    public float speed = 1;
    public bool active = false;
    private Animator animator;

    private void Start()
    {
        if (isRigidbody)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (animator)
            {
                if (!animator.GetBool("Moving")) { animator.SetBool("Moving", true); }
            }
            if (isRigidbody)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, transform.TransformDirection(moveDirection.normalized) * speed, 0.5f);
            }
            else
            {
                transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
            }
        }
        else if (animator)
        {
        if (animator.GetBool("Moving")) { animator.SetBool("Moving", false); }
        }
    }
}
