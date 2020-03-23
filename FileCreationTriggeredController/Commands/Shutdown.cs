using System.Collections.Generic;

namespace FileCreationTriggeredController.Commands
{
	class Shutdown : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "Shutdown" };

		public void Execute()
		{
			ProcessUtils.Start("shutdown", "/s /t 15 /c \"FileCreationTriggeredController will shutdown this computer in 15 seconds\"");
		}
	}
}
