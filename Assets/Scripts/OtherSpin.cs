using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSpin : MonoBehaviour
{
    public float speed = 1;
    public Vector3 spinAxis = Vector3.up;
    public bool isRigidbody = false;
    private Rigidbody rb;
    public bool active = false;

    private void Start()
    {
        if (isRigidbody)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (isRigidbody)
            {
                rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, spinAxis.normalized * speed, 0.5f);
            }
            else
            {
                transform.Rotate(spinAxis, speed * Time.deltaTime);
            }
        }
    }
}
