using Entitas;
using UnityEngine;

public class InitHourlyBonusFeature : IInitializeSystem
{
	public void Initialize()
	{
		//		PlayerPrefs.DeleteAll();

		if (IsBonusActivated())
		{
			Contexts.sharedInstance.events.CreateEntity().AddStartHourlyBonusEvent(true);
		}
	}

	private bool IsBonusActivated()
	{
		return PlayerPrefs.GetInt(Constants.HOURLY_BONUS_IS_CLICKED) == 1;
	}
}