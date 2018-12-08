using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {

	public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
	IEnumerator  Start() {
		WWW www = new WWW(url);
		yield return www;
		//Debug.Log (www);
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www.texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
