using System;
using Entitas;

public class AbstractGameFeature : Systems, IGameFeature
{
	private string _name;
	private Contexts _contexts;
	private bool _isActive;

	public AbstractGameFeature(string featureName, Contexts contexts, bool active = true)
	{
		_name = featureName;
		_contexts = contexts;
		_isActive = active;
		SetupSystems();
	}

	public override void Initialize()
	{
		base.Initialize();
		_contexts.core.CreateEntity().AddGameFeature(this);
	}

	protected virtual void SetupSystems()
	{
		// need to be overridden in children
		throw new NotImplementedException();
	}

	public override void Execute()
	{
		if (isActive)
		{
			base.Execute();
		}
	}

	public string Name
	{
		get { return _name; }
	}

	public void Activate()
	{
		if (isActive == false)
		{
			isActive = true;
			ActivateReactiveSystems();
		}
	}

	public void Deactivate()
	{
		if (isActive)
		{
			isActive = false;
			DeactivateReactiveSystems();
		}
	}

	public bool isActive
	{
		get { return _isActive; }
		private set { _isActive = value; }
	}

	public Contexts contexts
	{
		get { return _contexts; }
	}
}