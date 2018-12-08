using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Jackpot : MonoBehaviour {
	public static double jackpot = 10000f;

	public Text jackpotText;
	public double saveTimer;

	// Use this for initialization

	void Awake() {
		Load();
	}

	void Start() {

	}

	// Update is called once per frame
	void Update() {
		jackpot += 0.1f * Time.deltaTime;
		jackpotText.text = "Jackpot: " + jackpot;

		saveTimer += Time.deltaTime;
		if (((int)saveTimer) % 5 == 0 && saveTimer - (int)saveTimer <= 2 * Time.deltaTime) {
			Save();
		}
	}

	public static void ResetJackpot() {
		jackpot = 10000f;
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".dat");

		JackpotInternal jackpotData = new JackpotInternal();
		jackpotData.jackpot = jackpot;

		bf.Serialize (file, jackpotData);
		file.Close();
	}

	public void Load() {
		String filename = Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".dat";
		if (File.Exists(filename)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filename, FileMode.Open);

			JackpotInternal jackpotData = (JackpotInternal)bf.Deserialize (file);
			file.Close();

			jackpot = jackpotData.jackpot;
		}
	}

}

[Serializable]
public class JackpotInternal {
	public double jackpot;
}