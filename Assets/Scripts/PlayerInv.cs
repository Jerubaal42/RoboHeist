using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInv : MonoBehaviour
{

    public static PlayerInv playerInv;
    public float weight = 0;
    public float invReturnDistance = 0.1f;
    public int batteries = 0;
    public List<GameObject> batteryObjects = new List<GameObject>();
    public List<BatteryOperated> batteryToCharge = new List<BatteryOperated>();
    public Text weightText;
    public Text batText;

    void Awake()
    {
        playerInv = this;
    }

    private void Update()
    {
        if (Input.GetButton("LaunchBattery"))
        {
            if(batteryToCharge.Count > 0)
            {
                if(batteries >= batteryToCharge[0].powerReq)
                {
                    batteries -= batteryToCharge[0].powerReq;
                    batteryToCharge[0].Charge();
                    batteryToCharge.RemoveAt(0);
                }
            }
        }
    }
}
