using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateSpin : MonoBehaviour
{
    public GameObject spinObject;
    public bool active = false;
    public bool toggleOnLeave = false;
    public bool weighted = false;
    public float weight = 1;
    public bool inverted = false;

    private void Start()
    {
        spinObject.GetComponent<Spin>().enabled = inverted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Weighted")
        {
            if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
            {
                spinObject.GetComponent<Spin>().enabled = !inverted;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if (other.tag == "Player" || other.tag == "Weighted")
            {
                if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                {
                    spinObject.GetComponent<Spin>().enabled = inverted;
                }
            }
        }
    }
}
