
public class PlayerBalanceFeature : AbstractGameFeature
{
	public const string NAME = "PlayerBalanceFeature";

	public PlayerBalanceFeature(Contexts contexts, bool active) : base(NAME, contexts, active)
	{

	}

	protected override void SetupSystems()
	{
		Add(new SetBalanceSystem(contexts));
	}
}