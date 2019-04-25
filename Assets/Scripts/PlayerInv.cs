using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{

    public static PlayerInv playerInv;
    public float weight = 0;

    void Awake()
    {
        playerInv = this;
    }
}
