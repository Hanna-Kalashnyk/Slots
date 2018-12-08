using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

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
		//UnityPurchasing.Initialize(this);

		coreFeature.Initialize();
	}

	void Update()
	{
      //  if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SlotMegaBucks"))


        { coreFeature.Execute();
            coreFeature.Cleanup(); }
	}
}