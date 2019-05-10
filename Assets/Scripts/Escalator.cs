using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    public GameObject step;
    public Vector3 baseStep;
    public Vector3 finalStep;
    public Vector3 depthOffset;
    private Vector3 baseStepOffset;
    private Vector3 finalStepOffset;
    public float speed;
    private float cycle;
    private GameObject[] stepList;
    public int stepNumber;
    public bool active = true;
    private float offsetLengthRatio;
    private float mainLengthRatio;

    void Awake()
    {
        stepList = new GameObject[stepNumber];
        for (int i = 0; i < stepNumber; i++)
        {
            stepList[i] = Instantiate(step,transform);
        }
        baseStepOffset = baseStep + depthOffset;
        finalStepOffset = finalStep + depthOffset;
        FindRatio();
        for(int i = 0; i < stepList.Length; i++)
        {
            stepList[i].transform.position = Lerp4(baseStep, finalStep, finalStepOffset, baseStepOffset, mainLengthRatio, offsetLengthRatio, (float)i / stepNumber);
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
                stepList[i].GetComponent<Rigidbody>().MovePosition(Lerp4(baseStep, finalStep, finalStepOffset, baseStepOffset, mainLengthRatio, offsetLengthRatio, curCycle / stepNumber));
            }
        }
    }

    private void FindRatio()
    {
        float a = (baseStep - finalStep).magnitude;
        float b = depthOffset.magnitude;
        float c = 2 * a + 2 * b;
        offsetLengthRatio = b / c;
        mainLengthRatio = a / c;
    }

    private Vector3 Lerp4(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float ratAB, float ratBC, float t)
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
        else if(t < 2 * ratAB + ratBC)
        {
            result = Vector3.Lerp(c, d, (t - (ratAB + ratBC)) * (1 / ratAB));
        }
        else
        {
            result = Vector3.Lerp(d, a, (t - (2 * ratAB + ratBC)) * (1 / ratBC));
        }
        return result;
    }
}
