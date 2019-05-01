using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBucksBanner : MonoBehaviour {



    public GameObject eaglePrefab;
    GameObject eaglePrefabClone;
    private bool MoveBanners;
    private bool MoveBannersBefor;
    // Use this for initialization
    void Start()
    {
        MoveBannersBefor = true;
        MoveBanners = MoveBannersBefor;
        StartCoroutine(EagleBanner());
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (MoveBanners != MoveBannersBefor)
            {
                if (MoveBanners)
                {
                    StartCoroutine(EagleBanner());
                }
                else Destroy(eaglePrefabClone);
            }
            MoveBannersBefor = MoveBanners;
        }
    }


    IEnumerator EagleBanner()
    {
        eaglePrefabClone = Instantiate(eaglePrefab, transform.position, Quaternion.identity) as GameObject;
        eaglePrefabClone.transform.Rotate(90, 180, 0, Space.Self);
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
