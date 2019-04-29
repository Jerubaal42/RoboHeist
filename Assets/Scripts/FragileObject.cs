using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileObject : BreakableObject
{
    public float breakforce = 25f;
    private bool broken = false;
    public bool breakOnPlayer = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!broken)
        {
            if (collision.relativeVelocity.sqrMagnitude > breakforce || collision.gameObject.tag == "Player")
            {
                broken = true;
                BreakThis();
            }
        }
    }
}
