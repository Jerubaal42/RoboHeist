using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBreakOther : ButtonBase
{
    public BreakableObject breakObject;
    public bool explode = false;
    public float explodeSpeed = 50f;

    protected override void OnTriggerEnter(Collider other)
    {
        if (breakObject != null)
        {
            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if (changeCamera != null) { changeCamera.Activate(); }
                        if (explode)
                        {
                            breakObject.ExplodeThis(explodeSpeed);
                        }
                        else
                        {
                            breakObject.BreakThis();
                        }
                    }
                }
            }
        }
    }
}
