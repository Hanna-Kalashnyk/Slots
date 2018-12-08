using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScore : MonoBehaviour {

    public int score;

	// Use this for initialization
	void Start () {
        score = 0;
        GetComponent<Text>().text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
