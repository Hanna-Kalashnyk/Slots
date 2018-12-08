using System.Collections.Generic;
using Entitas;
using UnityEngine.Events;

public class RegisterFeatureSystem : ReactiveSystem<CoreEntity>, IInitializeSystem
{
	private FeaturesModel _model;
	private EventsContext _eventsContext;

	public RegisterFeatureSystem(Contexts contexts) : base(contexts.core)
	{

	}

	public void Initialize()
	{
		var contexts = Contexts.sharedInstance;
		_eventsContext = contexts.events;

		var modelEntity = contexts.core.CreateEntity();
		modelEntity.AddFeaturesModel(new Dictionary<string, IGameFeature>(), new Dictionary<string, UnityAction>());
		_model = modelEntity.featuresModel;
	}

	protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
	{
		return context.CreateCollector(CoreMatcher.GameFeature);
	}

	protected override bool Filter(CoreEntity entity)
	{
		return entity.hasGameFeature;
	}

	protected override void Execute(List<CoreEntity> entities)
	{
		foreach (var mainEntity in entities)
		{
			var gameFeature = mainEntity.gameFeature.feature;
			_model.map[gameFeature.Name] = gameFeature;

			_eventsContext.CreateEntity().AddRegisteredFeatureEvent(mainEntity.gameFeature.feature.Name);
		}
	}
}