using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMovingDown : MonoBehaviour
{

    public GameObject tablo;
    public float distance;
    public float totalRunningTime;
    int elona;
  
    void Start()
    {
        elona = Elona.Slot.ElosUI.currentSpingNumber;

    }


    void Update()
    {
        if (Elona.Slot.ElosUI.currentSpingNumber != elona)
        {
            elona = Elona.Slot.ElosUI.currentSpingNumber;
            if (elona % 3 == 0)
            {
                StartCoroutineMoveDown();   //moving game tablo down 
            }
        }
    }


    public void StartCoroutineMoveUp()
    {
        StartCoroutine(MoveUp(distance, totalRunningTime));
    }

    public void StartCoroutineMoveDown()
    {

        StartCoroutine(MoveDown(distance, totalRunningTime));

    }


    public IEnumerator MoveUp(float distance, float totalRunningTime)
    {
        Vector3 start = tablo.transform.position;
        Vector3 end = start + Vector3.up * distance;
        //total time this has been running
        float runningTime = 0;
        //the longest it would take to get to the destination at this speed

        //for the length of time it takes to get to the end position
        while (runningTime / totalRunningTime <= 0.98)
        {
            //keep track of the time each frame
            runningTime += Time.deltaTime;
            //lerp between start and end, based on the current amount of time that has passed
            // and the total amount of time it would take to get there at this speed.
            tablo.transform.position = Vector3.Lerp(start, end, runningTime / totalRunningTime);
            yield return 0;
        }
        tablo.transform.position = end;
    }

    public IEnumerator MoveDown(float distance, float totalRunningTime)
    {
        Vector3 start = tablo.transform.position;
        Vector3 end = start + Vector3.down * distance;
        float runningTime = 0;
        while (runningTime / totalRunningTime <= 0.98)
        {
            runningTime += Time.deltaTime;
            tablo.transform.position = Vector3.Lerp(start, end, runningTime / totalRunningTime);
            yield return 0;
        }

        tablo.transform.position = end;

    }

    public void StartCoroutineToInfo(int i)
    {
        if (i % 2 != 0)
            StartCoroutine(MoveDown(6, 1));
        if (i % 2 == 0)
            StartCoroutine(MoveUp(6, 1));
    }
}