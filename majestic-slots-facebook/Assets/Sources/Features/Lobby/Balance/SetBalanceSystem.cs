using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SetBalanceSystem : ReactiveSystem<CoreEntity>
{
	private ISetBalance _balanceListener;

	public SetBalanceSystem(Contexts contexts) : base(contexts.core)
	{
		contexts.uIListeners.GetGroup(UIListenersMatcher.SetBalanceListener).OnEntityAdded +=
			OnListenerLoaded;
	}

	private void OnListenerLoaded(IGroup<UIListenersEntity> @group, UIListenersEntity uiListenersEntity, int index, IComponent component)
	{
		_balanceListener = uiListenersEntity.setBalanceListener.value;
		SetBalance(Constants.PLAYER_BALANCE_DEFAULT);
	}

	protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
	{
		return context.CreateCollector(CoreMatcher.Balance);
	}

	protected override bool Filter(CoreEntity entity)
	{
		return entity.hasBalance;
	}

	protected override void Execute(List<CoreEntity> entities)
	{
		foreach (var entity in entities)
		{
			SetBalance(entity.balance.value);
		}
	}

	private void SetBalance(int amount)
	{
		var currentBalance = 0;
		if (PlayerPrefs.GetInt (Constants.PLAYER_BALANCE) != 0) {
			currentBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
		} 
		else 
		{
			currentBalance = 1000;
		}
		var increasedBalance = currentBalance + amount;
		PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, increasedBalance);
		_balanceListener.SetBalance(increasedBalance);
	}

}