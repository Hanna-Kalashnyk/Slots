using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOODLUCK: MonoBehaviour
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
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        if (Time.timeSinceLevelLoad <= n + 1.0f)
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
}


