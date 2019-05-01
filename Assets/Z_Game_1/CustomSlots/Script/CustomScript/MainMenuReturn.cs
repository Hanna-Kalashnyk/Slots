using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuReturn : MonoBehaviour {

	void Start () {
		Button btn = this.transform.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){		
		SceneManager.LoadScene ("Lobby");
	}
}
