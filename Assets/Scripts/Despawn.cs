using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float despawnTime = 1f;
    public float despawnRand = 0.5f;
    private float curTime = 0;

    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= Random.Range(despawnTime - despawnRand, despawnTime + despawnRand))
        {
            Destroy(gameObject);
        }
    }
}
