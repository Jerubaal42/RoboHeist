using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerDoor : ButtonBase
{
    public Door door;

    protected override void OnTriggerEnter(Collider other)
    {
        if (door != null)
        {
            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if (changeCamera != null) { changeCamera.Activate(); }
                        door.isOpen = !inverted;
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
                if (door != null)
                {
                    if (other.tag == "Player" || other.tag == "Weighted")
                    {
                        if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                        {
                            if (changeCamera != null) { changeCamera.Activate(); }
                            door.isOpen = inverted;
                        }
                    }
                }
            }
        }
    }
}
