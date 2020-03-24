using System.IO;

namespace FileCreationTriggeredController
{
	static class FileReader
	{
		public static string GetContent(string fileName)
		{
			var file = Path.Combine(Program.WatcherDirectory, fileName);
			return File.ReadAllText(file);
		}
	}
}
