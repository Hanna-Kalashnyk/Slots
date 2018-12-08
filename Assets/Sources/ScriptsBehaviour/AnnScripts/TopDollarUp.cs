using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDollarUp : MonoBehaviour {
    float t = 0;
    float k = 0;
    private void Start()
    {

         t = Time.time;
        
    }
    void Update () {k = Time.time;
        if ((k-t)<3.0f)
        {
            transform.position += Vector3.up * 34f * Time.deltaTime;
        }
    }
}
