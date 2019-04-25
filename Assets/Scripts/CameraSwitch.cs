using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera attachedCamera;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
