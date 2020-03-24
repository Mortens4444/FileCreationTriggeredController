using System.Collections.Generic;
using FileCreationTriggeredController.Hardware.Audio;

namespace FileCreationTriggeredController.Commands
{
	class Mute : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(Mute) };

		public void Execute()
		{
			AudioHandler.SetMute(true);
		}
	}
}
