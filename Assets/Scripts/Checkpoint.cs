using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber = 0;
    public Camera checkpointCamera;

    private void Start()
    {
        LoadScript.loader.checkpointCamera[checkpointNumber] = checkpointCamera;
        LoadScript.loader.checkpointPos[checkpointNumber] = transform.position;
        LoadScript.loader.checkpointRot[checkpointNumber] = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if(LoadScript.loader.checkpointCamera[checkpointNumber] != checkpointCamera) { LoadScript.loader.checkpointCamera[checkpointNumber] = checkpointCamera; }
        if (LoadScript.loader.checkpointCamera[checkpointNumber] != checkpointCamera) { LoadScript.loader.checkpointPos[checkpointNumber] = transform.position; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            if(other.tag == "Player")
            {
                if(LoadScript.loader.checkpointNumber < checkpointNumber)
                {
                    LoadScript.loader.checkpointNumber = checkpointNumber;
                    LoadScript.loader.playerWeight = PlayerInv.playerInv.weight;
                    LoadScript.loader.playerCharge = PlayerInv.playerInv.batteries;
                }
            }
        }
    }
}
