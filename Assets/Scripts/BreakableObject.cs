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

    public void ExplodeThis()
    {
        GameObject tempObject = Instantiate(brokenVersion, transform.position, transform.rotation);
        foreach(Transform child in tempObject.transform)
        {
            child.GetComponent<Rigidbody>().velocity += Random.onUnitSphere * 50;
        }
        Destroy(gameObject);
    }
}
