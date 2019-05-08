using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateSpin : ButtonBase
{
    public OtherSpin spinScript;

    protected override void OnTriggerEnter(Collider other)
    {
        if (spinScript != null)
        {
            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if (changeCamera != null) { changeCamera.Activate(); }
                        spinScript.active = !inverted;
                    }
                }
            }
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if (!other.isTrigger)
            {
                if (spinScript != null)
                {
                    if (other.tag == "Player" || other.tag == "Weighted")
                    {
                        if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                        {
                            if (changeCamera != null) { changeCamera.Activate(); }
                            spinScript.active = inverted;
                        }
                    }
                }
            }
        }
    }
}
