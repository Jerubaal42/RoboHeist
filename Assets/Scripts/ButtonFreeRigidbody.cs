using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFreeRigidbody : ButtonBase
{
    public Rigidbody target;

    protected override void OnTriggerEnter(Collider other)
    {
        if (target != null)
        {
            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if (changeCamera != null) { changeCamera.Activate(); }
                        target.constraints = RigidbodyConstraints.None;
                    }
                }
            }
        }
    }
}
