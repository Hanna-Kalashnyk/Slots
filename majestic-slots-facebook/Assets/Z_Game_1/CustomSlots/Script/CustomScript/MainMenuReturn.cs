using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuReturn : MonoBehaviour {

	void Start () {
		Button btn = this.transform.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	void TaskOnClick(){		
		SceneManager.LoadScene ("Lobby");
	}
}
