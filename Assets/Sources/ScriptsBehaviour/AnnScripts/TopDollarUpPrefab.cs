using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDollarUpPrefab : MonoBehaviour
{
    public GameObject topDollarUpPrefab;
    GameObject topDollarUpPrefabClone;
    int n = 0;
    // Use this for initialization
    void Start()
    {
       

    }
    void Update()
    {
        if (Elona.Slot.ElosUI.currentSpingNumber > 2 && n != Elona.Slot.ElosUI.currentSpingNumber)
        {

            n = Elona.Slot.ElosUI.currentSpingNumber;
            if (n % 3 == 0)
            {

                topDollarUpPrefabClone = Instantiate(topDollarUpPrefab, transform.position, Quaternion.identity) as GameObject;
            }
        }
        Destroy(topDollarUpPrefabClone, 5.0f);
    }
   


}
