using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Slot1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = this.transform.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TaskOnClick(){
		SceneManager.LoadScene("Slot1");
	}



}
