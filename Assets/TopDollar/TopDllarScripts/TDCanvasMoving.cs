using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TDCanvasMoving : MonoBehaviour {

    public GameObject tablo;
    public float distance;
    public float totalRunningTime;
    int elona;


    FirstOffer FirstOffer;

    //resizing of GoodLuck element
    public GameObject GoodLuck;
    public float ScalingFactor = 20.7f;
    public float TimeScale = 0.5f;
    private Vector3 InitialScale;
    private Vector3 FinalScale;

    // connection to ather classes   
    public RandomRotation rtarget; //The object we want to rotate
  
    public DTHighLightsRandomOn lights; //The object we want to light

    private float time;
    public float timeDelay;

    void Start()
    {
        elona = Elona.Slot.ElosUI.currentSpingNumber;
        // InitialScale = transform.localScale;
        InitialScale = new Vector3(40.0f, 40f, 0.0f);
        FinalScale = new Vector3(InitialScale.x + ScalingFactor, InitialScale.y + ScalingFactor, InitialScale.z);
    }


    void Update()
    {
        if (Elona.Slot.ElosUI.currentSpingNumber != elona)
        {
            elona = Elona.Slot.ElosUI.currentSpingNumber;
            if (elona % 3 == 0)
            {
                FirstOffer.countForThree = -1;
                StartCoroutineMoveDown();   // game tablo is moving down 

               StartCoroutine (Resizing());  //resizing of Title

                time = 0.0f;
                StartCoroutine(StartFirstRandom());




            }
        }
    }


    public IEnumerator StartFirstRandom()
    {
        while (timeDelay > time)
        {
            time += Time.deltaTime;
            yield return 0;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SlotMegaBucks1"))
        {
            FirstOffer.countForThree = -1;
            lights.StartTDHihgLighting();
            
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SlotTopDollarRound"))
        {
            FirstOffer.countForThree = -1;
            rtarget.StartRoundRotation();
        
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
        yield return 0;
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


    //resizing of GoodLuck element
    IEnumerator Resizing()
    {
        float progress = 0;

        while (progress <= 0.98)
        {
            GoodLuck.transform.localScale = Vector3.Lerp(InitialScale, FinalScale, progress);
            progress += Time.deltaTime * TimeScale;
            yield return null;
        }
        GoodLuck.transform.localScale = FinalScale;
    }

    public void StartCoroutineSHrinking()
    {

        StartCoroutine(SHrinking());
    }

    IEnumerator SHrinking()
    {
        float progress = 0;

        while (progress <= 0.98)
        {
            GoodLuck.transform.localScale = Vector3.Lerp(FinalScale, InitialScale, progress);
            progress += Time.deltaTime * TimeScale;
            yield return null;
        }
        GoodLuck.transform.localScale = InitialScale;
    }

}
