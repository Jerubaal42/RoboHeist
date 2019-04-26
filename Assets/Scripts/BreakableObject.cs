using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenVersion;

    public void BreakThis()
    {
        Instantiate(brokenVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
