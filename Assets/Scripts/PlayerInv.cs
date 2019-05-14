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
    public Image useImage;
    public Text useText;

    void Awake()
    {
        playerInv = this;
    }

    private void Start()
    {
        weightText.text = weight + " Pounds";
        batText.text = batteries + " Batteries";
    }

    private void Update()
    {
        if (batteryToCharge.Count > 0)
        {
            useImage.enabled = true;
            useText.enabled = true;
            useText.text = batteries >= batteryToCharge[0].powerReq ? "Activate " + batteryToCharge[0].name + " using " + batteryToCharge[0].powerReq + " batteries" : "Need " + batteryToCharge[0].powerReq + " batteries to activate " + batteryToCharge[0].name;
            if (Input.GetButton("LaunchBattery"))
            {
                if (batteries >= batteryToCharge[0].powerReq)
                {
                    batteries -= batteryToCharge[0].powerReq;
                    batteryToCharge[0].Charge();
                    batteryToCharge.RemoveAt(0);
                    UpdateText();
                }
            }
        }
        else
        {
            useImage.enabled = false;
            useText.enabled = false;
        }
    }

    public void UpdateText()
    {
        weightText.text = weight + " Pounds";
        batText.text = batteries + " Batteries";
    }
}
