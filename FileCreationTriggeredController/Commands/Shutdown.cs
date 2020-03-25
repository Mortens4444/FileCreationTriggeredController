using System.Collections.Generic;
using FileCreationTriggeredController.Utils;

namespace FileCreationTriggeredController.Commands
{
	class Shutdown : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(Shutdown) };

		public void Execute()
		{
			ProcessUtils.Start("shutdown", "/s /t 15 /c \"FileCreationTriggeredController will shutdown this computer in 15 seconds\"");
		}
	}
}
