using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDollarSliding : MonoBehaviour {

    int n;
    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {

            if (Time.time <=  2)
            {
                transform.position += Vector3.right * 40f * Time.deltaTime;
                transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
            }
            else
             if (Time.time <= 4)
            {
                transform.position += Vector3.right * 40f * Time.deltaTime;
                transform.localScale -= new Vector3(0.3f, 0.03f, 0.03f);
            }
            else
            if (Time.time <=  6)
            {
                transform.position += Vector3.left * 40f * Time.deltaTime;
                transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);

            }
            else
            if (Time.time<=  8)
            {
                transform.position += Vector3.left * 40f * Time.deltaTime;
                transform.localScale -= new Vector3(0.03f, 0.03f, 0.3f);

            }
    }
}
