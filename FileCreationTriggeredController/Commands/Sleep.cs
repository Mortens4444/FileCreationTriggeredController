using System.Collections.Generic;
using System.Windows.Forms;
using FileCreationTriggeredController.Hardware.Display;

namespace FileCreationTriggeredController.Commands
{
	class Sleep : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(Sleep) };

		public void Execute()
		{
			DisplayDevices.TurnOff();
			Application.SetSuspendState(PowerState.Suspend, true, true);
		}
	}
}
