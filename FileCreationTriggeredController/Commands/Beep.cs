using System;
using System.Collections.Generic;

namespace FileCreationTriggeredController.Commands
{
	class Beep : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(Beep) };

		public void Execute()
		{
			Console.WriteLine("\a");
		}
	}
}
