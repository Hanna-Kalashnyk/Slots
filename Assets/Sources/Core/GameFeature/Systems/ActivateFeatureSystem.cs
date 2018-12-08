using System.Collections.Generic;
using Entitas;

public class ActivateFeatureSystem : ReactiveSystem<EventsEntity>, IInitializeSystem
{
	private CoreContext _coreContext;
	private EventsContext _eventsContext;
	private FeaturesModel _model;

	public ActivateFeatureSystem(Contexts contexts) : base(contexts.events)
	{
		_coreContext = contexts.core;
		_eventsContext = contexts.events;
	}

	public void Initialize()
	{
		_model = _coreContext.featuresModel;
	}

	protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
	{
		return context.CreateCollector(EventsMatcher.ActivateFeatureEvent);
	}

	protected override bool Filter(EventsEntity entity)
	{
		return true;
	}

	protected override void Execute(List<EventsEntity> entities)
	{
		foreach (var entity in entities)
		{
			var featureName = entity.activateFeatureEvent.featureName;

			var feature = _model.map[featureName];
			feature.Activate();

			_eventsContext.CreateEntity().AddFeatureActivatedEvent(featureName);
		}
	}
}