using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBase : MonoBehaviour
{
    public bool active = false;
    public bool toggleOnLeave = false;
    public bool weighted = false;
    public float weight = 1;
    public bool inverted = false;
    public ChangeCamera changeCamera = null;

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        
    }
}
