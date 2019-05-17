using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            LoadScript.loader.sceneName = nextLevel;
            LoadScript.loader.checkpointNumber = 0;
            LoadScript.loader.playerWeight = 0;
            LoadScript.loader.playerCharge = 0;
            LoadScript.loader.Save();
            Pause.pause.ChangeScene(nextLevel);
        }
    }
}
