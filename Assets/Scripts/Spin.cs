using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 1;
    public Vector3 spinAxis = Vector3.up;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(spinAxis * spinSpeed);
    }
}
