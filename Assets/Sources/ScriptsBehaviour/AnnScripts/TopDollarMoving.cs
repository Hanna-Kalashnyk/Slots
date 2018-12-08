using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDollarMoving : MonoBehaviour
{
    void Update()
    {

        if (Time.timeSinceLevelLoad <= 2)
        {
            transform.position += Vector3.up * 40f * Time.deltaTime;
        }
       /* else
        {
           if (Time.time <= 3)
                {
                transform.position += Vector3.left * 20f * Time.deltaTime;
                //transform.localScale -= new Vector3(0.03F, 0.03F, 0.03F);
            }
        }*/
    }
}