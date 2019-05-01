using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstOffer : MonoBehaviour {
    public Text offerText;
    public static int countForThree;
    private TextMeshProUGUI m_Text;
  

    void Start () {
            offerText.text = "FIRST OFFER";
        m_Text = GetComponent<TextMeshProUGUI>();
        

    }

    // Change Title of Offer number in accordiance of TryAgain Tapping number
    void Update() { if (countForThree <= 0)       { offerText.text = "FIRST OFFER"; print("000"); m_Text.text = "FIRST OFFER"; }
            if (countForThree == 1)       { offerText.text = "SECOND OFFER"; print("111"); m_Text.text = "SECOND OFFER"; }
        if (countForThree == 2)       { offerText.text = "LAST OFFER"; print("222"); m_Text.text = "LAST OFFER"; }
       // else { offerText.text = "FIRST OFFER"; print("333"); }
    }
 
}
