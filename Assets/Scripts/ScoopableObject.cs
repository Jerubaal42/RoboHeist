using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopableObject : MonoBehaviour
{
    public float weight = 1;
    public bool isCarried = false;
    private Transform vacuumBox;

    void Start()
    {
        vacuumBox = PlayerInv.playerInv.gameObject.transform;
        if (isCarried) { PlayerInv.playerInv.weight += weight; gameObject.layer = 8; }
    }

    void Update()
    {
        if (isCarried && (transform.position - vacuumBox.position).sqrMagnitude > PlayerInv.playerInv.invReturnDistance)
        {
            transform.position = vacuumBox.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isCarried && collision.gameObject.tag == "Player")
        {
            isCarried = true;
            PlayerInv.playerInv.weight += weight;
            gameObject.layer = 8;
            gameObject.GetComponent<Rigidbody>().mass = 0.01f;
        }
    }
}
