
public class HourlyBonusFeature : AbstractGameFeature
{
	public const string NAME = "HourlyBonusFeature";

	public HourlyBonusFeature(Contexts contexts, bool active) : base(NAME, contexts, active)
	{
		
	}

	protected override void SetupSystems()
	{
		Add(new InitHourlyBonusFeature());
		Add(new OnClickHourlyBonusStateSystem(contexts));
		Add(new StartHourlyBonusStateSystem(contexts));
	}
}