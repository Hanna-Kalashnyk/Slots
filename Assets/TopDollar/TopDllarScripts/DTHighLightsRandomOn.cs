using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elona.Slot;
using UnityEngine.UI;
using System;





public class DTHighLightsRandomOn : MonoBehaviour {

    // List of all highLights

    List<GameObject> lightList = new List<GameObject>();
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;
    public GameObject Light6;
    public GameObject Light7;
    public GameObject Light8;
    public GameObject Light9;
    public GameObject Light10;

    FirstOffer FirstOffer;
    
    
    public void StartTDHihgLighting() {
               if (FirstOffer.countForThree  < 2)
        {
            FirstOffer.countForThree ++ ;
           // TurnOffLights();
            StartCoroutine(TDHihgLighting());
            
        }
      
        return;
    }

  
    IEnumerator TDHihgLighting()
    {


        lightList.Add(Light1);
        lightList.Add(Light2);
        lightList.Add(Light3);
        lightList.Add(Light4);
        lightList.Add(Light5);
        lightList.Add(Light6);
        lightList.Add(Light7);
        lightList.Add(Light8);
        lightList.Add(Light9);
        lightList.Add(Light10);


        TurnOffLights();

       //  Choose 4 random highLights and enable it after 1 sec wait

        for (int i = 0; i < 4; i++)
        {
            int Rand = UnityEngine.Random.Range(0, lightList.Count);
            GameObject HighLightNumber = lightList[Rand];
            SpriteRenderer m_SpriteRenderer = new SpriteRenderer();


            m_SpriteRenderer = HighLightNumber.GetComponent<SpriteRenderer>();
            yield return new WaitForSeconds(1);
            m_SpriteRenderer.enabled = true;
            lightList.Remove(lightList[Rand]);          //  Remove chosen highLight for non-dublication

        }
    }

      public void TurnOffLights()
    {
        for (int num = 0; num<lightList.Count; num++)
        {
            SpriteRenderer n_SpriteRenderer = lightList[num].GetComponent<SpriteRenderer>();
             n_SpriteRenderer.enabled = false;
            // lightList[num].enabled = false;
        }
     }

}
