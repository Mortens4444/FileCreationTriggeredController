using System.IO;
using System.Threading;

namespace FileCreationTriggeredController
{
	static class FileReader
	{
		public static string GetContent(string filename)
		{
			string result;
			Thread.Sleep(1000);
			var filepath = Path.Combine(Program.WatcherDirectory, filename);
			using (var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				using (var streamReader = new StreamReader(fileStream))
				{
					result = streamReader.ReadToEnd();
					streamReader.Close();
				}
				fileStream.Close();
			}
			return result;
		}
	}
}
