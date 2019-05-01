using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDollarSliding : MonoBehaviour {
    private float t;
    private int n;
    // Use this for initialization
    void Start()
    {
        t = Time.time;
        n = 0;
    }

    void Update()
    {
        n = (int)((Time.time-t) / 30);

        if (Time.time-t <= n*30 + 3)
            {
                transform.position += Vector3.right * 1.4f * Time.deltaTime;
           
            }
            else
             if (Time.time - t >= n * 30 + 5 && Time.time - t <= n * 30 + 8)
            {
                transform.position += Vector3.left * 1.4f * Time.deltaTime;
           
            }
    }
}
