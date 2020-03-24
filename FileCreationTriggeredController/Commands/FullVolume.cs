using System.Collections.Generic;
using FileCreationTriggeredController.Hardware.Audio;

namespace FileCreationTriggeredController.Commands
{
	class FullVolume : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(FullVolume) };

		public void Execute()
		{
			AudioHandler.SetMasterVolume(100);
		}
	}
}
