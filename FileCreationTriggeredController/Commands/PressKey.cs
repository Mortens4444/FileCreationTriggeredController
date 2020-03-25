using System.Collections.Generic;
using System.Windows.Forms;

namespace FileCreationTriggeredController.Commands
{
	class PressKey : ICommand
	{
		public IEnumerable<string> CommandNames => new[] { nameof(PressKey) };
		private readonly Dictionary<string, string> specialValues = new Dictionary<string, string>
		{
			{ "space", " " },
			{ "one", "1" },
			{ "two", "2" },
			{ "three", "3" },
			{ "four", "4" },
			{ "five", "5" },
			{ "six", "6" },
			{ "seven", "7" },
			{ "eight", "8" },
			{ "nine", "9" },
			{ "zero", "0" }
		};


		public void Execute()
		{
			var key = FileReader.GetContent(nameof(PressKey));
			if (specialValues.ContainsKey(key))
			{
				SendKeys.SendWait(specialValues[key]);
			}
			else
			{
				SendKeys.SendWait(key);
			}
		}
	}
}
