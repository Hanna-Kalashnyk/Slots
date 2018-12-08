using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovesRight : MonoBehaviour
{
    void Update()
    {

        if (Time.timeSinceLevelLoad > 2 && Time.timeSinceLevelLoad <= 30)
        {
            transform.position += Vector3.right * 30f * Time.deltaTime;
        }
    }
}