using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateEscalator : ButtonBase
{
    public Escalator escalator;

    protected override void OnTriggerEnter(Collider other)
    {
        if (escalator != null)
        {
            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if(changeCamera != null) { changeCamera.Activate(); }
                        escalator.active = !inverted;
                    }
                }
            }
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if (escalator != null)
            {
                if (!other.isTrigger)
                {
                    if (other.tag == "Player" || other.tag == "Weighted")
                    {
                        if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                        {
                            if (changeCamera != null) { changeCamera.Activate(); }
                            escalator.active = inverted;
                        }
                    }
                }
            }
        }
    }
}
