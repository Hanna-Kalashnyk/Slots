using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
public class MegabucksAnimation : MonoBehaviour
{
    private int n = -1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       n = (int)Time.timeSinceLevelLoad / 20 ;
              
            if (Time.timeSinceLevelLoad <= n * 20 + 5)
            {
                transform.position += Vector3.left * 1.5f * Time.deltaTime;
            }
            else
              if (Time.timeSinceLevelLoad <= n * 20 + 10)
            {
                transform.position += Vector3.right * 1.5f * Time.deltaTime;

            }
            
           
    }
}
