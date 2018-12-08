
public interface ISetHourlyBonusState
{
	void ActivateCollect();
	void ActivateWait();
	void SetElapsedTime(string time);
}

[UIListeners]
public class SetHourlyBonusStateListener : UIListener
{
	public ISetHourlyBonusState state;
}