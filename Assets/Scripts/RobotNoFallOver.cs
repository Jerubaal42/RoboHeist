using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotNoFallOver : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().centerOfMass = Vector3.down * transform.localScale.y;
    }
}
