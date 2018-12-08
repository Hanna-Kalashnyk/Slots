using UnityEngine;
using System.Collections;

public class PostData : MonoBehaviour {

	void Start () {

		string url = "http://localhost:4000/users/postBalance/1";

		WWWForm form = new WWWForm();
		form.AddField("balance", "700");
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www) {
		yield return www;

			// check for errors
			if (www.error == null)
			{
				Debug.Log("WWW Ok!: " + www.text);
			} else {
				Debug.Log("WWW Error: "+ www.error);
			}    
	}    
}
