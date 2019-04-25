using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    public static CameraMenu camMenu;
    public Camera currentCamera;
    private Camera thisCamera;
    private bool isActive = false;

    void Awake()
    {
        camMenu = this;
    }

    private void Start()
    {
        thisCamera = gameObject.GetComponent<Camera>();
        currentCamera.enabled = true;
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
        if (isActive)
        {
            thisCamera.depth = -5;
            isActive = false;
            PlayerMove.player.isControlled = true;
        }
        else
        {
            thisCamera.depth = 5;
            isActive = true;
            PlayerMove.player.isControlled = false;
        }
        return isActive;
    }

    public bool ToggleCameraMenu(bool active)
    {
        if (active)
        {
            thisCamera.depth = 5;
            isActive = true;
            PlayerMove.player.isControlled = false;
        }
        else
        {
            thisCamera.depth = -5;
            isActive = false;
            PlayerMove.player.isControlled = true;
        }
        return isActive;
    }

    public void ChangeCamera(Camera camera)
    {
        if (currentCamera != camera)
        {
            currentCamera.enabled = false;
            camera.enabled = true;
            currentCamera = camera;
        }
        ToggleCameraMenu(false);
    }
}
