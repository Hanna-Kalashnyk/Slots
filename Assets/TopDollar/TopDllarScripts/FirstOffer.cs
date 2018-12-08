using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstOffer : MonoBehaviour {
    public Text offerText;
    public static int countForThree;

    void Start () {
            offerText.text = "FIRST OFFER";

    }

    // Change Title of Offer number in accordiance of TryAgain Tapping number
    void Update() { if (countForThree <= 0)       { offerText.text = "FIRST OFFER"; print("000"); }
            if (countForThree == 1)       { offerText.text = "SECOND OFFER"; print("111"); }
        if (countForThree == 2)       { offerText.text = "LAST OFFER"; print("222"); }
       // else { offerText.text = "FIRST OFFER"; print("333"); }
    }
 
}
