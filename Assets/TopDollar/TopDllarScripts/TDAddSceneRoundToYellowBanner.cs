using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TDAddSceneRoundToYellowBanner : MonoBehaviour {
    public void OnMouseDown()
    {
        SceneManager.LoadScene("SlotMegaBucks1");
    }

    public void TDloadSceneRound()
    {
        SceneManager.LoadScene("SlotTopDollarRound");
    }

}