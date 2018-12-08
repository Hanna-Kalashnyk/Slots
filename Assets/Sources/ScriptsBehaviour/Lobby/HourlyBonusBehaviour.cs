using UnityEngine;
using UnityEngine.UI;

public class HourlyBonusBehaviour : MonoBehaviour, ISetHourlyBonusState
{
	[SerializeField]
	private GameObject _collectBonusContainer;

	[SerializeField]
	private GameObject _waitBonusContainer;

	[SerializeField]
	private Button _collectBonusButton;

	[SerializeField]
	private Button _waitBonusButton;

	[SerializeField]
	private Text _waitBonusTimer;


    [SerializeField]
    private Text _balance;

	private Contexts _contexts;

	void Start()
	{
		SubscribeOnListeners();
	}

	private void SubscribeOnListeners()
	{
		_collectBonusButton.onClick.AddListener(OnCollectBonusClick);
		_waitBonusButton.onClick.AddListener(OnWaitBonusClick);

		_contexts = Contexts.sharedInstance;
		_contexts.uIListeners.CreateEntity().AddSetHourlyBonusStateListener(this);
	}

	private void OnCollectBonusClick()
	{
		_contexts.events.CreateEntity().AddOnClickHourlyBonusStateEvent(true);

        System.Random random = new System.Random();
        int curBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, curBalance + random.Next(10000, 100000));
        _balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE).ToString();
	}

	private void OnWaitBonusClick()
	{

	}

	public void ActivateCollect()
	{
		_collectBonusContainer.SetActive(true);
		_waitBonusContainer.SetActive(false);
	}

	public void ActivateWait()
	{
		_waitBonusContainer.SetActive(true);
		_collectBonusContainer.SetActive(false);
	}

	public void SetElapsedTime(string time)
	{
		_waitBonusTimer.text = time;
	}
}