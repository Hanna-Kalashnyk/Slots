using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerSeriaVioletBanner : MonoBehaviour {
    public GameObject VioletBannerPrefab;
    GameObject VioletBannerPrefabClone;
    private bool MoveBanners;
    private bool MoveBannersBefor;
    // Use this for initialization
    void Start () {
        MoveBannersBefor = true;
        MoveBanners = MoveBannersBefor;
        StartCoroutine(VioletBanner());
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (MoveBanners != MoveBannersBefor)
            {
                if (MoveBanners)
                {
                    StartCoroutine(VioletBanner());
                }
                else Destroy(VioletBannerPrefabClone);
            }
            MoveBannersBefor = MoveBanners;
        }
    }


    IEnumerator VioletBanner()
    {
        VioletBannerPrefabClone = Instantiate(VioletBannerPrefab, transform.position, Quaternion.identity) as GameObject;
        VioletBannerPrefabClone.transform.Rotate(0, 180, 0, Space.Self);
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
