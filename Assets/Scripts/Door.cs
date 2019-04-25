using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float weightNeeded = 10;
    public bool isOpen = false;
    public float openTime = 1;
    public float openWidth = 1.5f;
    [Range(0f, 1f)]
    public float openPercent = 0;
    public bool openTop = false;
    public bool openBottom = false;
    public bool openLeft = false;
    public bool openRight = false;
    private Transform doorTop;
    private Transform doorBottom;
    private Transform doorLeft;
    private Transform doorRight;
    public bool playerTrigger = true;

    private void Awake()
    {
        if (openTop) { doorTop = transform.Find("DoorTop"); }
        if (openBottom) { doorBottom = transform.Find("DoorBottom"); }
        if (openLeft) { doorLeft = transform.Find("DoorLeft"); }
        if (openRight) { doorRight = transform.Find("DoorRight"); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerTrigger)
        {
            if (other.tag == "Player")
            {
                if (PlayerInv.playerInv.weight >= weightNeeded)
                {
                    isOpen = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerTrigger)
        {
            if (other.tag == "Player")
            {
                isOpen = false;
            }
        }
    }

    private void Update()
    {
        openPercent += (Time.deltaTime * (isOpen ? 1 : -1)) / openTime;
        openPercent = Mathf.Clamp01(openPercent);
        OpenDoor(openPercent);
    }

    private void OpenDoor(float percentOpen)
    {
        if (openTop) { doorTop.localPosition = Vector3.Lerp(Vector3.up, Vector3.up + (Vector3.up * (openWidth / 2)), percentOpen); }
        if (openBottom) { doorBottom.localPosition = Vector3.Lerp(Vector3.down, Vector3.down + (Vector3.down * (openWidth / 2)), percentOpen); }
        if (openLeft) { doorLeft.localPosition = Vector3.Lerp(Vector3.left, Vector3.left + (Vector3.left * (openWidth / 2)), percentOpen); }
        if (openRight) { doorRight.localPosition = Vector3.Lerp(Vector3.right, Vector3.right + (Vector3.right * (openWidth / 2)), percentOpen); }
    }
}
