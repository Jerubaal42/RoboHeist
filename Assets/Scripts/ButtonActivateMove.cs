using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateMove : MonoBehaviour
{
    public OtherMove moveScript;
    public bool active = false;
    public bool toggleOnLeave = false;
    public bool weighted = false;
    public float weight = 1;
    public bool inverted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (moveScript != null)
        {
            if (other.tag == "Player" || other.tag == "Weighted")
            {
                if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                {
                    moveScript.active = !inverted;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if(moveScript != null) {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        moveScript.active = inverted;
                    }
                }
            }
        }
    }
}
