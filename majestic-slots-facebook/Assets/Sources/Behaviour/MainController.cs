using UnityEngine;

public class MainController : MonoBehaviour
{
	public static CoreFeature coreFeature;
	private Contexts _contexts;
	public int balance;

	void Start()
	{
		Screen.fullScreen = false;
		Screen.orientation = ScreenOrientation.Landscape;
		InitFeatures();
	}

	private void InitFeatures()
	{
		_contexts = Contexts.sharedInstance;
		coreFeature = new CoreFeature(_contexts, true);

		coreFeature.Add(new PlayerBalanceFeature(_contexts, true));
		coreFeature.Add(new HourlyBonusFeature(_contexts, true));
		coreFeature.Add(new PushNotificationsFeature(_contexts, true));
			
		// FacebookFeature
		// PaymentFeature
		// GamesFeature

		coreFeature.Initialize();
	}

	void Update()
	{
		coreFeature.Execute();
		coreFeature.Cleanup();
	}
}