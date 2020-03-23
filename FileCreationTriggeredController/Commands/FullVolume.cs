using System.Collections.Generic;
using FileCreationTriggeredController.Audio;

namespace FileCreationTriggeredController.Commands
{
	class FullVolume : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "FullVolume" };

		public void Execute()
		{
			AudioHandler.SetMasterVolume(100);
		}
	}
}
