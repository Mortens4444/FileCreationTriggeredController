using System.Collections.Generic;
using FileCreationTriggeredController.Hardware.Audio;

namespace FileCreationTriggeredController.Commands
{
	class UnMute : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(UnMute) };

		public void Execute()
		{
			AudioHandler.SetMute(false);
		}
	}
}
