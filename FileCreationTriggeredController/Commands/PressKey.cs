using System.Collections.Generic;
using System.Windows.Forms;

namespace FileCreationTriggeredController.Commands
{
	class PressKey : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(PressKey) };

		public void Execute()
		{
			var key = FileReader.GetContent(nameof(PressKey));
			if (key == "space")
			{
				SendKeys.SendWait(" ");
			}
			else
			{
				SendKeys.SendWait(key);
			}
		}
	}
}
