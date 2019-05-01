using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerSeriaCats : MonoBehaviour
{

    public GameObject catPrefab;
    GameObject catPrefabClone;
    private bool MoveBanners;
    private bool MoveBannersBefor;
    // Use this for initialization
    void Start()
    {
        MoveBannersBefor = true;
        MoveBanners = MoveBannersBefor;
        StartCoroutine(CatBanner());
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (MoveBanners != MoveBannersBefor)
            {
                if (MoveBanners)
                {
                    StartCoroutine(CatBanner());
                }
                else Destroy(catPrefabClone);
            }
            MoveBannersBefor = MoveBanners;
        }
    }


    IEnumerator CatBanner()
    {
        catPrefabClone = Instantiate(catPrefab, transform.position, Quaternion.identity) as GameObject;
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
