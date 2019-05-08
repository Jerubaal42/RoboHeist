using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateMove : ButtonBase
{
    public OtherMove moveScript;

    protected override void OnTriggerEnter(Collider other)
    {
        if (moveScript != null)
        {
            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if(changeCamera != null) { changeCamera.Activate(); }
                        moveScript.active = !inverted;
                    }
                }
            }
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if (moveScript != null)
            {
                if (!other.isTrigger)
                {
                    if (other.tag == "Player" || other.tag == "Weighted")
                    {
                        if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                        {
                            if (changeCamera != null) { changeCamera.Activate(); }
                            moveScript.active = inverted;
                        }
                    }
                }
            }
        }
    }
}
