using UnityEngine;
using System.Collections;

public class LoadData : MonoBehaviour {
	public UnityEngine.UI.Text text;
	public string url = "http://localhost:4000/users/getBalance/1";
	IEnumerator  Start() {
		WWW www = new WWW(url);
		yield return www;
		Debug.Log (www.text);
		text.text = www.text;

		//Renderer renderer = this.GetComponent<Renderer>();
		///renderer.material.mainTexture = www.texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
