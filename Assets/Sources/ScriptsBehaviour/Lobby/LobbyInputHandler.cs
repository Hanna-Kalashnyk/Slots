using UnityEngine;
using UnityEngine.UI;

public class LobbyInputHandler : MonoBehaviour
{

	[SerializeField]
	public GameObject _payTable;

	[SerializeField]
	private Button _buy;

	[SerializeField]
	private Button _payTableButton;

	[SerializeField]
	private Button _bannerGame;

	[SerializeField]
	private Button _facebook;

	void Start()
	{		
		_bannerGame.onClick.AddListener(OnBannerGameClick);
		_buy.onClick.AddListener(TogglePayTable);
		_facebook.onClick.AddListener(OnFacebookClick);
		_payTableButton.onClick.AddListener(OnDimmingBehindClick);
	}

	private void TogglePayTable() {					
		_payTable.SetActive(!_payTable.activeSelf);
	}

	private void OnBannerGameClick()
	{
		print("OnBannerGameClick");
	}

	private void OnFacebookClick()
	{
		print("OnFacebookClick");
	}

	private void OnDimmingBehindClick()
	{
		_payTable.SetActive(!_payTable.activeSelf);
	}
}