using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileCreationTriggeredController.Utils
{
	static class DirectoryUtils
	{
		public static FileInfo[] GetFilesWithExtensions(this DirectoryInfo directoryInfo, string searchPattern, SearchOption searchOption, params string[] extensions)
		{
			return directoryInfo.EnumerateFiles(searchPattern, searchOption)
				.Where(file => extensions.Contains(Path.GetExtension(file.Name).ToLower()))
				.ToArray();
		}
	}
}
