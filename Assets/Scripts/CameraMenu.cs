using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    public static CameraMenu camMenu;
    public Canvas cameraCanvas;

    void Start()
    {
        camMenu = this;
        cameraCanvas = GameObject.Find("CameraCanvas").GetComponent<Canvas>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("TabMenu"))
        {
            ToggleCameraMenu();
        }
    }

    public bool ToggleCameraMenu()
    {
        if (cameraCanvas.enabled)
        {
            cameraCanvas.enabled = false;
            return false;
        }
        else
        {
            cameraCanvas.enabled = true;
            return true;
        }
    }

    public bool ToggleCameraMenu(bool active)
    {
        if (active)
        {
            cameraCanvas.enabled = true;
            return true;
        }
        else
        {
            cameraCanvas.enabled = false;
            return false;
        }
    }
}
