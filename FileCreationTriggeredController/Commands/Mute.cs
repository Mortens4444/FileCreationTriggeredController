using System.Collections.Generic;
using FileCreationTriggeredController.Audio;

namespace FileCreationTriggeredController.Commands
{
	class Mute : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "Mute" };

		public void Execute()
		{
			AudioHandler.SetMute(true);
		}
	}
}
