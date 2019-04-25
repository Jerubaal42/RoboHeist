using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerIcon : MonoBehaviour
{
    public Transform player;
    
    void Update()
    {
        transform.position = new Vector3(player.position.x, 20, player.position.z);
        transform.rotation = Quaternion.Euler(90, player.rotation.eulerAngles.y + 180,0);
    }
}
