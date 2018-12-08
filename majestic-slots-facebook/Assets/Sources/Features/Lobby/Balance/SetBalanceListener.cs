using Entitas;

public interface ISetBalance
{
	void SetBalance(int value);
}

[UIListeners]
public class SetBalanceListener : IComponent
{
	public ISetBalance value;
}