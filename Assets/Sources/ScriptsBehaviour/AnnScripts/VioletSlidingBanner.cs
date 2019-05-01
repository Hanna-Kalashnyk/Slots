using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VioletSlidingBanner : MonoBehaviour
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

        if (Time.time - t <= n * 30 + 13 && Time.time - t >= n * 30 + 10)
        {
            transform.position += Vector3.right * 1.4f * Time.deltaTime;

        }
        else
             if (Time.time - t >= n * 30 + 15 && Time.time - t <= n * 30 + 18)
        {
            transform.position += Vector3.left * 1.4f * Time.deltaTime;

        }
    }
   
}
