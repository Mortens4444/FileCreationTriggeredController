using System;
using System.IO;

namespace FileCreationTriggeredController.Utils
{
	class FileUtils
	{
		public static string GetFileContent(string filename)
		{
			string result;
			if (File.Exists(filename))
			{
				using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (var streamReader = new StreamReader(fileStream))
					{
						result = streamReader.ReadToEnd();
						streamReader.Close();
					}
					fileStream.Close();
				}
			}
			else
			{
				throw new FileNotFoundException(String.Concat("File not found: ", filename), filename);
			}
			return result;
		}

		public static string SearchForFirst(string directory, string searchPattern, string[] extensions)
		{
			try
			{
				var directoryInfo = new DirectoryInfo(directory);
				var result = directoryInfo.GetFilesWithExtensions(searchPattern, SearchOption.TopDirectoryOnly, extensions);
				if (result.Length > 0)
				{
					return result[0].FullName;
				}

				var subdirectories = Directory.GetDirectories(directory);
				for (var i = 0; i < subdirectories.Length; i++)
				{
					var found = SearchForFirst(subdirectories[i], searchPattern, extensions);
					if (found != null)
					{
						return found;
					}
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ExceptionDetails.Get(ex));
			}
			return null;
		}
	}
}
