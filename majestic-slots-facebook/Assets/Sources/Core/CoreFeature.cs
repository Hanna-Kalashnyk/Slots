
public class CoreFeature : AbstractGameFeature
{
	public CoreFeature(Contexts contexts, bool active) : base("CoreFeature", contexts, active)
	{

	}

	protected override void SetupSystems()
	{
		// core systems
		Add(new RegisterFeatureSystem(contexts));
		Add(new ActivateFeatureSystem(contexts));
		Add(new DeactivateFeatureSystem(contexts));

		// Cleanup events
		Add(new CleanEventsSystem(contexts.events));
	}
}