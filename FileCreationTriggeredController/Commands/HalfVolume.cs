using System.Collections.Generic;
using FileCreationTriggeredController.Audio;

namespace FileCreationTriggeredController.Commands
{
	class HalfVolume : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "HalfVolume" };

		public void Execute()
		{
			AudioHandler.SetMasterVolume(50);
		}
	}
}
