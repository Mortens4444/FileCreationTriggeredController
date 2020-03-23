using System;
using System.Collections.Generic;
using System.Linq;
using FileCreationTriggeredController.Commands;

namespace FileCreationTriggeredController
{
	static class CommandListBuilder
	{
		public static Dictionary<string, ICommand> GetCommands()
		{
			var result = new Dictionary<string, ICommand>();
			var commands = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => !type.IsInterface && typeof(ICommand).IsAssignableFrom(type));

			foreach (var command in commands)
			{
				var newCommand = (ICommand)Activator.CreateInstance(command);
				foreach (var commandName in newCommand.CommandNames)
				{
					result.Add(commandName.ToLower(), newCommand);
				}
			}
			return result;
		}
	}
}
