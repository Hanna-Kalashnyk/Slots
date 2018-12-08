using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MegabucksRotation: MonoBehaviour
{
    //float translateSpeed = 0.1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, 1 ,0) * 100 * Time.deltaTime);
    }
}
