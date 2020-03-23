using System.Collections.Generic;
using System.Windows.Forms;

namespace FileCreationTriggeredController.Commands
{
	class Hibernate : ICommand
	{
		public IEnumerable<string> CommandNames => new [] { "Hibernate" };

		public void Execute()
		{
			Application.SetSuspendState(PowerState.Hibernate, true, true);
		}
	}
}
