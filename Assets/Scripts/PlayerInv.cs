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
        UpdateText();
    }

    private void Update()
    {
        if (batteryToCharge.Count > 0)
        {
            useImage.enabled = true;
            useText.enabled = true;
            useText.text = batteries >= batteryToCharge[0].powerReq ? "Activate " + batteryToCharge[0].name + " using " + VerboseInt(batteryToCharge[0].powerReq) + " batteries" : "Need " + VerboseInt(batteryToCharge[0].powerReq) + " batteries to activate " + batteryToCharge[0].name;
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
        weightText.text = VerboseInt((int)weight) + " Ounces";
        batText.text = VerboseInt(batteries) + " Batteries";
    }

    public string VerboseInt(int i)
    {
        return i < 20
            ? DataPackage.numNameS[i] :
                (
                    i < 100
                    ?
                    (
                        i % 10 == 0
                        ? DataPackage.numNameL[(i / 10) - 2] :
                        DataPackage.numNamePre[(i / 10) - 2] + DataPackage.numNameS[i % 10]
                    )
                    :
                    (
                        i < 2000
                        ? DataPackage.numNameS[i / 100]
                        :
                        (
                            i / 100 % 10 == 0
                            ? DataPackage.numNameL[(i / 1000) - 2]
                            : DataPackage.numNamePre[(i / 1000) - 2] + DataPackage.numNameS[i % 1000 / 100]
                        )
                    )
                    +
                    (
                        i % 100 == 0
                        ? DataPackage.numNameL[8]
                        : DataPackage.numNamePre[8] +
                        (
                            i % 100 < 20 ?
                            DataPackage.numNameS[i % 100] :
                            batteries % 10 == 0
                            ? DataPackage.numNameL[(i % 100 / 10) - 2]
                            : DataPackage.numNamePre[(i % 100 / 10) - 2] + DataPackage.numNameS[i % 10]
                        )
                    )
                );
    }
}
