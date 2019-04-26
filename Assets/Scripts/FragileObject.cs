using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileObject : BreakableObject
{
    public float breakforce = 25f;
    private bool broken = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.sqrMagnitude > breakforce && !broken)
        {
            broken = true;
            BreakThis();
        }
    }
}
