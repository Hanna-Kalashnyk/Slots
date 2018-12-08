using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class BuyGameBehaviour : MonoBehaviour {

	[SerializeField]
	public Text _Balance;

	[SerializeField]
	public GameObject _payTableForGame;

	[SerializeField]
	private Button _backOfPayTable;

	[SerializeField]
	public Button _game3;

	[SerializeField]
	public GameObject _game3PadLock;

	[SerializeField]
	public GameObject _game3Pay;

	private static IStoreController m_StoreController;          // The Unity Purchasing system.

/**
	[SerializeField]
	public Button _game4;

	[SerializeField]
	public Button _game5;

	[SerializeField]
	public GameObject _game4Pay;

	[SerializeField]
	public GameObject _game5Pay;
**/

	// Use this for initialization
	void Start () {
		_backOfPayTable.onClick.AddListener(HidePayTable);
		_game3.onClick.AddListener(ShowPayTableForGame3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void HidePayTable() {					
		_payTableForGame.SetActive(false);
		_game3Pay.SetActive (false);
	}

	private void ShowPayTableForGame3() {				

		Product game3Product = IAPButton.IAPButtonStoreManager.Instance.StoreController.products.WithID ("majestic.game3");
		if (game3Product != null && game3Product.hasReceipt) {
			_game3PadLock.SetActive (false);
		}

		if (game3Product == null || game3Product.hasReceipt == false) {
			_payTableForGame.SetActive(true);
			_game3Pay.SetActive (true);
		} 
	}

	public void game3Bought() {
		_game3PadLock.SetActive (false);
		_game3.onClick.RemoveListener (ShowPayTableForGame3);

		int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 3500000;
		PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
		_Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";

	}

}
