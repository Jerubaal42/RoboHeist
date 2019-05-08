using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveOther : ButtonBase
{
    public GameObject objectToMove;
    public Vector3 distanceToMove = Vector3.zero;
    public Vector3 rotationToRotate = Vector3.zero;
    public bool fling = false;
    public Vector3 flingDirection = Vector3.zero;
    public float flingForce = 1;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public bool reusable = false;
    public bool moved = true;
    public float moveTime = 1;
    private float durationMoved = 0;

    private void Start()
    {

        initialPosition = objectToMove.transform.position;
        initialRotation = objectToMove.transform.rotation;
    }

    private void Update()
    {
        if (!fling)
        {
            if (!moved)
            {
                if (objectToMove != null)
                {
                    if (active)
                    {
                        if (durationMoved / moveTime < 1)
                        {
                            durationMoved += Time.deltaTime;
                            objectToMove.transform.position = Vector3.Lerp(initialPosition, initialPosition + distanceToMove, durationMoved / moveTime);
                            objectToMove.transform.rotation = Quaternion.Slerp(initialRotation, initialRotation * Quaternion.Euler(rotationToRotate), durationMoved / moveTime);
                        }
                        else
                        {
                            objectToMove.transform.position = initialPosition + distanceToMove;
                            objectToMove.transform.rotation = initialRotation * Quaternion.Euler(rotationToRotate);
                            durationMoved = moveTime;
                            moved = true;
                        }
                    }
                    if (!active)
                    {
                        if (durationMoved / moveTime > 0)
                        {
                            durationMoved -= Time.deltaTime;
                            objectToMove.transform.position = Vector3.Lerp(initialPosition, initialPosition + distanceToMove, durationMoved / moveTime);
                            objectToMove.transform.rotation = Quaternion.Slerp(initialRotation, initialRotation * Quaternion.Euler(rotationToRotate), durationMoved / moveTime);
                        }
                        else
                        {
                            objectToMove.transform.position = initialPosition;
                            objectToMove.transform.rotation = initialRotation;
                            durationMoved = 0;
                            moved = true;
                        }
                    }
                }
            }
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(objectToMove != null) {

            if (!other.isTrigger)
            {
                if (other.tag == "Player" || other.tag == "Weighted")
                {
                    if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                    {
                        if (changeCamera != null) { changeCamera.Activate(); }
                        if (fling && (reusable || !active))
                        {
                            objectToMove.GetComponent<Rigidbody>().isKinematic = false;
                            objectToMove.GetComponent<Rigidbody>().AddForce(flingDirection.normalized * flingForce);
                            active = true;
                        }
                        else
                        {
                            active = true;
                            moved = false;
                        }
                    }
                }
            }
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (toggleOnLeave)
        {
            if (objectToMove != null)
            {
                if (!other.isTrigger)
                {
                    if (other.tag == "Player" || other.tag == "Weighted")
                    {
                        if (!weighted || PlayerInv.playerInv.weight > weight || other.tag == "Weighted")
                        {
                            if (!fling)
                            {
                                if (changeCamera != null) { changeCamera.Activate(); }
                                active = false;
                                moved = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
