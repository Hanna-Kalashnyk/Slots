using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour {
       int n;
    void Start()
    {
        
        gameObject.GetComponent<Light>().intensity = 0.0f;
        
    }

    void FixedUpdate()
    {

        // if (light.intensity != constantIntens) light.intensity = constantIntens;

        // if (TimeDown > 0) TimeDown -= Time.deltaTime;

        // if (TimeDown < 0) TimeDown = 0;

        // if (TimeDown == 0)

        n = (int)Time.timeSinceLevelLoad;

        if (Time.timeSinceLevelLoad <= n  + 0.5f)
        {
            gameObject.GetComponent<Light>().intensity = 0.0f;
        }
        else
        if (Time.timeSinceLevelLoad <= n + 1.0f)
        {
            gameObject.GetComponent<Light>().intensity = 0.5f;
        }
    }
}
