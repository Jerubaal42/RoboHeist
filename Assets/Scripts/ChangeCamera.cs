using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera destCamera;
    private Camera prevCamera;
    public float viewTime = 3f;
    private float curTime = 0f;
    public bool active = false;
    
    void Update()
    {
        if (active)
        {
            curTime += Time.deltaTime;
            if(curTime >= viewTime)
            {
                Deactivate();
            }
        }
    }

    public void Activate()
    {
        active = true;
        prevCamera = CameraMenu.camMenu.currentCamera;
        CameraMenu.camMenu.allowChange = false;
        CameraMenu.camMenu.ChangeCamera(destCamera);
        PlayerMove.player.isControlled = false;
        curTime = 0;
    }

    public void Deactivate()
    {
        active = false;
        CameraMenu.camMenu.ChangeCamera(prevCamera);
        CameraMenu.camMenu.allowChange = true;
    }
}
