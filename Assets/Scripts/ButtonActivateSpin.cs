using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateSpin : MonoBehaviour
{
    public OtherSpin spinScript;
    public bool active = false;
    public bool toggleOnLeave = false;
    public bool weighted = false;
    public float weight = 1;
    public bool inverted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (spinScript != null)
        {
            if (other.tag == "Player" || other.tag == "Weighted")
            {
                if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                {
                    spinScript.active = !inverted;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if(spinScript != null) {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        spinScript.active = inverted;
                    }
                }
            }
        }
    }
}
