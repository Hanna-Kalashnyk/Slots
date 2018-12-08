using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class SlotGamesLauncherBehaviour : MonoBehaviour
{
	[SerializeField]
	private Button _slotGame1;
	[SerializeField]
	private Button _slotGame2;
	[SerializeField]
	private Button _slotGame3;
    [SerializeField]
    private Button _slotGame4;

    [SerializeField]
	private GameObject _bigSafariBanner;

	[SerializeField]
	private GameObject _buyGameWindow;

	[SerializeField]
	private GameObject _bigSafariPadLock;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start()
	{        
		_slotGame1.onClick.AddListener(OnSlotGame1Click);
		_slotGame2.onClick.AddListener(OnSlotGame2Click);
		_slotGame3.onClick.AddListener(StartGame3);
        _slotGame4.onClick.AddListener(OnSlotGame4Click);

       // Product product = IAPButton.IAPButtonStoreManager.Instance.StoreController.products.WithID("majestic.game3");
		//if (product != null && product.hasReceipt) {		
		//	_bigSafariPadLock.SetActive (false);
		//} else {
		//	_bigSafariPadLock.SetActive (true);
		//}
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

    private void OnSlotGame4Click()
    {
        //we need to stop lobby for timer. 
        //otherwise it crashes with trying to access old data.

        StopLobby();
        SceneManager.LoadScene("LoadingVideo");
        StartCoroutine(LoadGame1Scene("SlotGame4"));
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

	private void StartGame3() {
		Product product = IAPButton.IAPButtonStoreManager.Instance.StoreController.products.WithID("majestic.game3");
		if (product != null && product.hasReceipt) {
			_buyGameWindow.SetActive (true);
			_bigSafariBanner.SetActive (true);
			_bigSafariPadLock.SetActive (false);
		}
	}
}