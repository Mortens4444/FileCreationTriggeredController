using System.Collections.Generic;

namespace FileCreationTriggeredController.Commands
{
	interface ICommand
	{
		IEnumerable<string> CommandNames { get; }

		void Execute();
	}
}
