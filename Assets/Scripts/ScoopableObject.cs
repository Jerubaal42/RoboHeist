﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopableObject : MonoBehaviour
{
    public float weight = 1;
    public int charge = 0;
    public bool isCarried = false;
    public bool isUsed = false;
    private Transform vacuumBox;

    void Start()
    {
        vacuumBox = PlayerInv.playerInv.gameObject.transform;
    }

    void Update()
    {
        if (isCarried && (transform.position - vacuumBox.position).sqrMagnitude > PlayerInv.playerInv.invReturnDistance && !isUsed)
        {
            transform.position = vacuumBox.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isCarried && collision.gameObject.tag == "Player")
        {
            Scoop();
        }
    }

    public void Scoop()
    {
        gameObject.layer = 8;
        gameObject.GetComponent<Rigidbody>().mass = 0.01f;
        isCarried = true;
        if (charge > 0)
        {
            PlayerInv.playerInv.batteries += charge;
            PlayerInv.playerInv.batteryObjects.Add(gameObject);
        }
        PlayerInv.playerInv.weight += weight;
        PlayerInv.playerInv.UpdateText();
    }
}
