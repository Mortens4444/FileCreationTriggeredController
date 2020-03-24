using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using FileCreationTriggeredController.Commands;

namespace FileCreationTriggeredController
{
	class FileSystemChangeTrigger
	{
		private static readonly Dictionary<string, ICommand> Commands = CommandListBuilder.GetCommands();
		private static FileSystemWatcher watcher;

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		public static void WatchDirectory(string directory)
		{
			watcher = new FileSystemWatcher()
			{
				Path = directory,
				NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
				Filter = "*",
				EnableRaisingEvents = true,
				InternalBufferSize = 65535
			};

			watcher.Created += OnCreated;
			watcher.Error += OnError;
		}

		private static void OnError(object sender, ErrorEventArgs e)
		{
			Console.Error.WriteLine(ExceptionDetails.Get(e.GetException()));
		}

		private static void OnCreated(object source, FileSystemEventArgs e)
		{
			var key = e.Name.ToLower();
			if (Commands.ContainsKey(key))
			{
				var command = Commands[key];
				try
				{
					command.Execute();
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ExceptionDetails.Get(ex));
				}
				var parent = Path.GetDirectoryName(e.FullPath);
				FolderCleaner.Clean(parent);
			}
		}
	}
}
