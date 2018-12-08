using Entitas;

public class CleanEventsSystem : ICleanupSystem
{
	private EventsContext _context;

	public CleanEventsSystem(EventsContext context)
	{
		_context = context;
	}

	public void Cleanup()
	{
		foreach (var entity in _context.GetEntities())
		{
			if (entity.isDeletionMark)
			{
				entity.Destroy();
			}
			else
			{
				entity.isDeletionMark = true;
			}
		}
	}
}