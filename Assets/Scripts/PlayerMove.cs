using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove player;
    public bool isControlled = false;
    private Rigidbody rb;
    public float moveSpeed = 1;
    public float turnSpeed = 1;
    public bool grounded = false;
    public bool upright = true;
    public bool rightObject = false;
    public int rightObjectStage = 0;
    public float uprightTimeout = 3f;
    public float uprightLiftTime = 1f;
    public float uprightDuration = 1f;
    public float uprightPause = 1f;
    private float upsideDownTime;
    private float uprightTimer = 0;
    private Vector3 curPos;
    private Quaternion curRot;

    private void Start()
    {
        player = this;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rightObject)
        {
            uprightTimer += Time.deltaTime;
            if (rightObjectStage == 0)
            {
                transform.position = Vector3.Lerp(curPos, curPos + Vector3.up, uprightTimer / uprightLiftTime);
                if (uprightTimer > uprightLiftTime)
                {
                    transform.position = curPos + Vector3.up;
                    uprightTimer = 0;
                    rightObjectStage++;
                }
            }
            if(rightObjectStage == 1)
            {
                transform.rotation = Quaternion.Lerp(curRot, Quaternion.Euler(0, curRot.eulerAngles.y, 0), uprightTimer / uprightDuration);
                if(uprightTimer > uprightDuration)
                {
                    transform.rotation = Quaternion.Euler(0, curRot.eulerAngles.y, 0);
                    uprightTimer = 0;
                    rightObjectStage++;
                }
            }
            if(rightObjectStage == 2)
            {
                if(uprightTimer > uprightPause)
                {
                    uprightTimer = 0;
                    rightObjectStage = 0;
                    rightObject = false;
                    rb.isKinematic = false;
                }
            }
        }
        else
        {
            upsideDownTime += Time.deltaTime;
            Debug.Log(rb.velocity);
            if (rb.velocity.y > -0.1 && rb.velocity.y < 0.1) { grounded = true; } else { grounded = false; upsideDownTime = 0; }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.5f, Color.cyan);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 0.5f)) { upright = true; upsideDownTime = 0; } else { upright = false; }
            if (isControlled && grounded && upright)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, transform.forward * Input.GetAxis("Vertical") * moveSpeed, 0.5f);
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * turnSpeed);
                }
            }
            if (upsideDownTime > uprightTimeout)
            {
                upsideDownTime = 0;
                rightObject = true;
                uprightTimer = 0f;
                rb.isKinematic = true;
                curPos = transform.position;
                curRot = transform.rotation;
            }
        }
    }
}
