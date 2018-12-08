using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunriseSlotMovesUp : MonoBehaviour
{
    void Update()
    {

        if (Time.timeSinceLevelLoad <= 2)
        {
            transform.position += Vector3.up * 42f * Time.deltaTime;
              }
    }
}