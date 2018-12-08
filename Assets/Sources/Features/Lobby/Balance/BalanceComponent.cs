using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Unique]
public class BalanceComponent : IComponent
{
	public int value;
}