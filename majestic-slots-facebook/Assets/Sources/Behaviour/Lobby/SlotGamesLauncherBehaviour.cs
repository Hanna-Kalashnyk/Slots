using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SlotGamesLauncherBehaviour : MonoBehaviour
{
	[SerializeField]
	private Button _slotGame1;
	[SerializeField]
	private Button _slotGame2;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start()
	{        
		_slotGame1.onClick.AddListener(OnSlotGame1Click);
		_slotGame2.onClick.AddListener(OnSlotGame2Click);
	}

	private void OnSlotGame1Click()
	{
		StopLobby(); 
		SceneManager.LoadScene("LoadingVideo");
		StartCoroutine(LoadGame1Scene("SlotGame1"));		
	}

	private void OnSlotGame2Click()
	{
        //we need to stop lobby for timer. 
        //otherwise it crashes with trying to access old data.

        StopLobby(); 
		SceneManager.LoadScene("LoadingVideo");
		StartCoroutine(LoadGame1Scene("SlotGame2"));		
	}

	private void StopLobby()
	{
		CoroutineManager.Instance.StopAllCoroutines();
		MainController.coreFeature.DeactivateReactiveSystems();
		Contexts.sharedInstance.Reset();
	}

	IEnumerator LoadGame1Scene(string sceneName) {		
		yield return new WaitForSeconds(3);		

		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);		
		yield return async;
	}
}