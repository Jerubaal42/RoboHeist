using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{

    public static PlayerInv playerInv;
    public float weight = 0;
    public float invReturnDistance = 0.25f;

    void Awake()
    {
        playerInv = this;
    }
}
