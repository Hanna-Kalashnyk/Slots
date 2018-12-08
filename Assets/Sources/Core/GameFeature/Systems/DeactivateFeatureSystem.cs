using System.Collections.Generic;
using Entitas;

public class DeactivateFeatureSystem : ReactiveSystem<EventsEntity>, IInitializeSystem
{
	private CoreContext _coreContext;
	private FeaturesModel _model;

	public DeactivateFeatureSystem(Contexts contexts) : base(contexts.events)
	{
		_coreContext = contexts.core;
	}

	public void Initialize()
	{
		_model = _coreContext.featuresModel;
	}

	protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
	{
		return context.CreateCollector(EventsMatcher.DeactivateFeatureEvent);
	}

	protected override bool Filter(EventsEntity entity)
	{
		return true;
	}

	protected override void Execute(List<EventsEntity> entities)
	{
		foreach (var eventsEntity in entities)
		{
			var toDeactivate = eventsEntity.deactivateFeatureEvent;
			var feature = _model.map[toDeactivate.featureName];
			feature.Deactivate();
		}
	}
}