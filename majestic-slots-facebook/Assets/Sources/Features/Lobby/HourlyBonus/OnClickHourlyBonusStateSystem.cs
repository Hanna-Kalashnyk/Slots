using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class OnClickHourlyBonusStateSystem : ReactiveSystem<EventsEntity>
{
	private EventsContext _events;

	public OnClickHourlyBonusStateSystem(Contexts contexts) : base(contexts.events)
	{
		_events = contexts.events;
	}

	protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
	{
		return context.CreateCollector(EventsMatcher.OnClickHourlyBonusStateEvent);
	}

	protected override bool Filter(EventsEntity entity)
	{
		return entity.hasOnClickHourlyBonusStateEvent;
	}

	protected override void Execute(List<EventsEntity> entities)
	{
		PlayerPrefs.SetInt(Constants.HOURLY_BONUS_IS_CLICKED, 1);
		PlayerPrefs.SetString(Constants.HOURLY_BONUS_NEXT_ACTIVE_TIME, DateTime.Now.AddMinutes(Constants.HOURLY_BONUS_WAIT_TIME).ToString());
		_events.CreateEntity().AddStartHourlyBonusEvent(true);
	}
}