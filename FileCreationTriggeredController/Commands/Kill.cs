using System.Collections.Generic;
using System.Diagnostics;

namespace FileCreationTriggeredController.Commands
{
	class Kill : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(Kill) };

		public void Execute()
		{
			var processName = FileReader.GetContent(nameof(Kill));
			var processes = Process.GetProcessesByName(processName);
			foreach (var process in processes)
			{
				process.Kill();
			}
		}
	}
}
