using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannersSeriaYellowTD1 : MonoBehaviour
{
    public GameObject topDollarUpPrefab;
    GameObject topDollarUpPrefabClone;
    private bool MoveBanners;
    private bool MoveBannersBefor;
    // Use this for initialization
    void Start()
    {
       MoveBannersBefor= true;
       MoveBanners = MoveBannersBefor;
        StartCoroutine(YellowTDBanner());
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (MoveBanners != MoveBannersBefor)
            {
                if (MoveBanners)
                {
                    StartCoroutine(YellowTDBanner());
                }
                else Destroy(topDollarUpPrefabClone);
            }
            MoveBannersBefor = MoveBanners ;
        }
    }


    IEnumerator YellowTDBanner()
    {
        topDollarUpPrefabClone = Instantiate(topDollarUpPrefab, transform.position, Quaternion.identity) as GameObject;
             yield return null;
    }

    public void StopBannersMoving()
    {
        MoveBanners = false; 
           }

    public void StartBannersMoving()
    {
        MoveBanners = true;
    }
}
