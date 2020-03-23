using System;
using System.IO;

namespace FileCreationTriggeredController
{
	static class FolderCleaner
	{
		public static void Clean(string directory)
		{
			var files = Directory.GetFiles(directory);
			foreach (var file in files)
			{
				try
				{
					File.Delete(file);
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ExceptionDetails.Get(ex));
				}
			}
			var subDirectories = Directory.GetDirectories(directory);
			foreach (var subDirectory in subDirectories)
			{
				try
				{
					Directory.Delete(subDirectory);
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ExceptionDetails.Get(ex));
				}
			}
		}
	}
}
