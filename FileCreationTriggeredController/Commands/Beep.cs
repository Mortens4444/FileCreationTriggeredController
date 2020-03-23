using System;
using System.Collections.Generic;

namespace FileCreationTriggeredController.Commands
{
	class Beep : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "Beep" };

		public void Execute()
		{
			Console.WriteLine("\a");
		}
	}
}
