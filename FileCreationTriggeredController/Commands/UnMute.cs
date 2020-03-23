using System.Collections.Generic;
using FileCreationTriggeredController.Audio;

namespace FileCreationTriggeredController.Commands
{
	class UnMute : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "Unmute" };

		public void Execute()
		{
			AudioHandler.SetMute(false);
		}
	}
}
