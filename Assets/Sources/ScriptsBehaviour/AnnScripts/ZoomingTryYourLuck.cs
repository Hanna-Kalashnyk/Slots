using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomingTryYourLuck : MonoBehaviour
{
    int n;
    void Start()
    {

          }

    void FixedUpdate()
    {
        n = (int)Time.timeSinceLevelLoad;

        if (Time.timeSinceLevelLoad <= n + 0.5f)
        {
            transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);
        }
        else
        if (Time.timeSinceLevelLoad <= n + 1.0f)
        {
            transform.localScale -= new Vector3(0.003f, 0.003f, 0.003f);
        }
    }
}
