using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
  //  public static int RotationNumber = 0;
    //Rotating a game object by a pivot point
    private float elapsedTime;
    public float rotationTime = 5f;
    public GameObject rtarget; //The object we want to rotate
 //   public static int RotationNumber;

    FirstOffer FirstOffer;

    /*  public void Update()
      {
          if (rCounts != RotationNumber)
          {
              if (RotationNumber<2)
              {
                  // elapsedTime = 0;
                  StartCoroutine(StartRoundRotationCC());
                  rCounts = RotationNumber;
              }
          }
      }
      */

    //  FirstOffer.countForThree = -1;

    private void Start()
    {
   //     RotationNumber = -1;
    }

    public void StartRoundRotation()
    {        if (FirstOffer.countForThree < 2)
        {
            FirstOffer.countForThree++;
               
            elapsedTime = 0;
            StartCoroutine(StartRoundRotationCC());
         }
       
    }

    public IEnumerator StartRoundRotationCC()
    {

        //  Vector3 startingPosition = transform.localPosition;
        Quaternion startingRotation = rtarget.transform.rotation; // have a startingRotation as well
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(90, 355)));
        while (rotationTime - elapsedTime > 0.01f)
        {
            elapsedTime += Time.deltaTime; // <- move elapsedTime increment here
                                           //  transform.localPosition = Vector3.Lerp(startingPosition, newLocalTarget, (elapsedTime / time)   );  
                                           // Rotations
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, (elapsedTime / rotationTime));
           yield return 0;
        }
        rtarget.transform.rotation = targetRotation;
                      
       yield return 0;
    }
}

