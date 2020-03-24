using System.Collections.Generic;
using FileCreationTriggeredController.Hardware.Audio;

namespace FileCreationTriggeredController.Commands
{
	class HalfVolume : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(HalfVolume) };

		public void Execute()
		{
			AudioHandler.SetMasterVolume(50);
		}
	}
}
