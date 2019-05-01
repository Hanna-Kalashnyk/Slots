using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSlidingBanner : MonoBehaviour
{
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
        n = (int)((Time.time - t) / 30);

        if (Time.time - t <= n * 30 + 23 && Time.time - t >= n * 30 + 20)
        {
            transform.position += Vector3.right * 1.5f * Time.deltaTime;

        }
        else
             if (Time.time - t >= n * 30 + 25 && Time.time - t <= n * 30 + 28)
        {
            transform.position += Vector3.left * 1.5f * Time.deltaTime;

        }
    }

}
