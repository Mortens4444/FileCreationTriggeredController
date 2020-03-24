using System.Collections.Generic;
using System.Windows.Forms;
using FileCreationTriggeredController.Hardware.Display;

namespace FileCreationTriggeredController.Commands
{
	class Hibernate : ICommand
	{
		public IEnumerable<string> CommandNames => new [] { nameof(Hibernate) };

		public void Execute()
		{
			DisplayDevices.TurnOff();
			Application.SetSuspendState(PowerState.Hibernate, true, true);
		}
	}
}
