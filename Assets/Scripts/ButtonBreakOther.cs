using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBreakOther : MonoBehaviour
{
    public BreakableObject breakObject;
    public bool explode = false;
    public bool active = false;
    public bool weighted = false;
    public float weight = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(breakObject != null) {
            if (other.tag == "Player" || other.tag == "Weighted")
            {
                if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                {
                    if (explode)
                    {
                        breakObject.ExplodeThis();
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
