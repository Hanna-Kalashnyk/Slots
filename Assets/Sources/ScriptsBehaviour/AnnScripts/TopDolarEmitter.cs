using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDolarEmitter : MonoBehaviour
{
    int n;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        // if (Time.timeSinceLevelLoad > 5.0)
        {
            n = (int)Time.timeSinceLevelLoad / 20;

            if (Time.timeSinceLevelLoad <= n * 20 + 2)
            {
                transform.position += Vector3.right * 1.5f * Time.deltaTime;
              //  transform.localScale += new Vector3(0.03F,0.03F,0.03F);
            }
         /*   else
             if (Time.timeSinceLevelLoad <= n * 20 + 4)
            {
                transform.position += Vector3.right * 1.5f * Time.deltaTime;
               // transform.localScale -= new Vector3(0.03F,0.03F,0.03F);
            }*/
            else
            if (Time.timeSinceLevelLoad <= (n * 20 + 7) && Time.timeSinceLevelLoad >= (n * 20 +5))
            {
                transform.position += Vector3.left * 1.5f * Time.deltaTime;
              // transform.localScale -= new Vector3(1.03F,1.03F,1.03F);

            }
           /* else
            if (Time.timeSinceLevelLoad <= n * 20 + 8)
            {
                transform.position += Vector3.left * 1f * Time.deltaTime;
               // transform.localScale -= new Vector3(0.03F,0.03F,0.03F);

            }*/
        }
    }
}
