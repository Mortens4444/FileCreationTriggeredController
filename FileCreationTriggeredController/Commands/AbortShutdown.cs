using System.Collections.Generic;
using FileCreationTriggeredController.Utils;

namespace FileCreationTriggeredController.Commands
{
	class AbortShutdown : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(AbortShutdown) };

		public void Execute()
		{
			ProcessUtils.Start("shutdown", "/a");
		}
	}
}
