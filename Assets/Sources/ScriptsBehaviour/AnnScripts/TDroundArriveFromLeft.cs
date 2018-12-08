using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDroundArriveFromLeft : MonoBehaviour {

	private float t;
    private float k = 0;
    public float delayTime = 2;
    public float arriveTime = 3;

    private void Start()
    {

        t = Time.time;

    }
    void Update()
    {
        k = Time.time;
        if (k> (t+ delayTime) && k < (t + delayTime +arriveTime))
        {
            transform.position += Vector3.right * 1.5f * Time.deltaTime;
        }
    }
}
