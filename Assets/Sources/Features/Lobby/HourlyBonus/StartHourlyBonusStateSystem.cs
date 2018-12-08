using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class StartHourlyBonusStateSystem : ReactiveSystem<EventsEntity>
{
	private CoreContext _coreContext;
	private UIListenersContext _uiListenersContext;
	private ISetHourlyBonusState _state;
	private readonly WaitForSeconds _delaySeconds = new WaitForSeconds(1.0f);

	public StartHourlyBonusStateSystem(Contexts contexts) : base(contexts.events)
	{
		_coreContext = contexts.core;
		_uiListenersContext = contexts.uIListeners;

		_uiListenersContext.GetGroup(UIListenersMatcher.SetHourlyBonusStateListener).OnEntityAdded +=
			(group, entity, index, component) => _state = entity.setHourlyBonusStateListener.state;
	}

	protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
	{
		return context.CreateCollector(EventsMatcher.StartHourlyBonusEvent);
	}

	protected override bool Filter(EventsEntity entity)
	{
		return entity.hasStartHourlyBonusEvent;
	}

	protected override void Execute(List<EventsEntity> entities)
	{
		CoroutineManager.StartC(StartCountDown());
	}

	IEnumerator StartCountDown()
	{
		_state.ActivateWait();

		while (true)
		{
			var nextBonusTime = DateTime.Parse(PlayerPrefs.GetString(Constants.HOURLY_BONUS_NEXT_ACTIVE_TIME));

			var elapsedTime = nextBonusTime.Subtract(DateTime.Now);

			if (elapsedTime.TotalSeconds < 1)
				break;

			_state.SetElapsedTime(String.Format("{0:D2}:{1:D2}:{2:D2}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds));

			yield return _delaySeconds;
		}

		_state.ActivateCollect();
        System.Random random = new System.Random();
        PlayerPrefs.SetInt(Constants.HOURLY_BONUS_IS_CLICKED, 0);
        _coreContext.CreateEntity().AddBalance(random.Next(10000, 100000));
	}
}