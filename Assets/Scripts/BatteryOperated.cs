using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryOperated : MonoBehaviour
{
    public bool active = false;
    public int powerReq = 1;
    public bool activateSpin = false;
    public bool activateMove = false;
    public bool activateDoor = false;
    public bool activateEscalator = false;
    public float batDelay = 0.5f;
    public float batTravelTime = 1;
    private int curBatPower = 0;
    private List<GameObject> batObjects = new List<GameObject>();
    private List<Vector3> playerPos = new List<Vector3>();
    private float batTime = 0;
    private GameObject player;
    private int batObjectCount;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(active)
        {
            batTime += Time.deltaTime;
            for(int i = batObjects.Count - 1; i >= 0; i--)
            {
                if (batTime > (batDelay * (batObjectCount - i)))
                {
                    if(batObjects[i].GetComponent<Rigidbody>().isKinematic == false)
                    {
                        foreach (Collider c in batObjects[i].GetComponentsInChildren<Collider>())
                        {
                            c.enabled = false;
                        }
                        batObjects[i].GetComponent<Rigidbody>().isKinematic = true;
                    }
                    batObjects[i].transform.position = BezierCurve(playerPos[i], Vector3.up * 5 + (playerPos[i] + transform.position) / 2, transform.position, (batTime - (batDelay * (batObjectCount - i))) / batTravelTime);
                    if ((batTime - (batDelay * (batObjectCount - i))) / batTravelTime > 1) { Destroy(batObjects[i]); batObjects.RemoveAt(i); }
                }
                else
                {
                    playerPos[i] = player.transform.position;
                }
            }
            if(batObjects.Count <= 0)
            {
                Activate();
                Destroy(this);
            }
        }
    }

    public void Activate()
    {
        if (activateMove)
        {
            if (gameObject.GetComponent<OtherMove>() != null)
            {
                gameObject.GetComponent<OtherMove>().active = true;
            }
        }
        if (activateSpin)
        {
            if (gameObject.GetComponent<OtherSpin>() != null)
            {
                gameObject.GetComponent<OtherSpin>().active = true;
            }
        }
        if (activateDoor)
        {
            if(gameObject.GetComponent<Door>() != null)
            {
                gameObject.GetComponent<Door>().isOpen = true;
            }
        }
        if (activateEscalator)
        {
            if(gameObject.GetComponent<Escalator>() != null)
            {
                gameObject.GetComponent<Escalator>().active = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active)
        {
            if (other.tag == "Player")
            {
                PlayerInv.playerInv.batteryToCharge.Add(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!active)
        {
            if (other.tag == "Player")
            {
                PlayerInv.playerInv.batteryToCharge.Remove(this);
            }
        }
    }

    public void Charge()
    {
        curBatPower = powerReq;
        foreach (GameObject battery in PlayerInv.playerInv.batteryObjects)
        {
            batObjects.Add(battery);
            batObjectCount++;
            curBatPower -= battery.GetComponent<ScoopableObject>().charge;
            if (curBatPower <= 0)
            {
                break;
            }
        }
        foreach(GameObject battery in batObjects)
        {
            battery.GetComponent<ScoopableObject>().isUsed = true;
            PlayerInv.playerInv.weight -= battery.GetComponent<ScoopableObject>().weight;
            PlayerInv.playerInv.batteryObjects.Remove(battery);
            playerPos.Add(player.transform.position);
        }
        batTime = 0;
        active = true;
    }

    private Vector3 BezierCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        t = Mathf.SmoothStep(0f, 1f, t);
        float u = 1 - t;
        Vector3 p = (u * u * a) + (2 * u * t * b) + (t * t * c);
        return p;
    }
}
