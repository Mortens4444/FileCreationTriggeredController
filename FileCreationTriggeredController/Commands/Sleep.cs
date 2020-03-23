using System.Collections.Generic;
using System.Windows.Forms;

namespace FileCreationTriggeredController.Commands
{
	class Sleep : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { "Sleep" };

		public void Execute()
		{
			Application.SetSuspendState(PowerState.Suspend, true, true);
		}
	}
}
