using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    public GameObject step;
    public Vector3 firstStep;
    public Vector3 secondStep;
    public Vector3 thirdStep;
    public Vector3 fourthStep;
    public float speed;
    private float cycle;
    private GameObject[] stepList;
    public int stepNumber;
    public bool active = true;
    private float abRat;
    private float bcRat;
    private float cdRat;
    private float daRat;

    void Awake()
    {
        stepNumber = Mathf.Max(stepNumber, 1);
        stepList = new GameObject[stepNumber];
        for (int i = 0; i < stepNumber; i++)
        {
            stepList[i] = Instantiate(step,transform);
        }
        FindRatio();
        for(int i = 0; i < stepList.Length; i++)
        {
            stepList[i].transform.position = Lerp4(firstStep, secondStep, thirdStep, fourthStep, abRat, bcRat, cdRat, daRat, (float)i / stepNumber);
        }
    }
    
    void FixedUpdate()
    {
        if (active)
        {
            cycle += Time.deltaTime * speed;
            for (int i = 0; i < stepList.Length; i++)
            {
                float curCycle = i + cycle;
                while(curCycle > stepNumber)
                {
                    curCycle -= stepNumber;
                }
                stepList[i].GetComponent<Rigidbody>().MovePosition(Lerp4(firstStep, secondStep, thirdStep, fourthStep, abRat, bcRat, cdRat, daRat, curCycle / stepNumber));
            }
        }
    }

    private void FindRatio()
    {
        float a = (firstStep - secondStep).magnitude;
        float b = (secondStep - thirdStep).magnitude;
        float c = (thirdStep - fourthStep).magnitude;
        float d = (fourthStep - firstStep).magnitude;
        float e = a + b + c + d;
        abRat = a / e;
        bcRat = b / e;
        cdRat = c / e;
        daRat = d / e;
    }

    private Vector3 Lerp4(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float ratAB, float ratBC, float ratCD, float ratDA, float t)
    {
        Vector3 result;
        if(t < ratAB)
        {
            result = Vector3.Lerp(a, b, t * (1 / ratAB));
        }
        else if(t < ratAB + ratBC)
        {
            result = Vector3.Lerp(b, c, (t - ratAB) * (1 / ratBC));
        }
        else if(t < ratAB + ratBC + ratCD)
        {
            result = Vector3.Lerp(c, d, (t - (ratAB + ratBC)) * (1 / ratCD));
        }
        else
        {
            result = Vector3.Lerp(d, a, (t - (ratAB + ratBC + ratCD)) * (1 / ratDA));
        }
        return result;
    }
}
