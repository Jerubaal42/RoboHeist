using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera attachedCamera;
    private SpriteRenderer spriteRenderer;
    public bool securityCameraSprite;
    public float yPos = 30;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        transform.position = new Vector3(attachedCamera.transform.position.x, yPos, attachedCamera.transform.position.z);
        transform.rotation = securityCameraSprite ? Quaternion.Euler(90, attachedCamera.transform.rotation.eulerAngles.y + 120, 0) : Quaternion.Euler(90, attachedCamera.transform.rotation.eulerAngles.y - 90, 0);
    }

    private void OnMouseDown()
    {
        CameraMenu.camMenu.ChangeCamera(attachedCamera);
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = Color.grey;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
}
