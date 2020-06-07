using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileCreationTriggeredController.Utils;

namespace FileCreationTriggeredController.Commands
{
	class NextEpisodeOf : ICommand
	{
		private const string MoviesFolder = @"D:\";
		private const string Vlc = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe";
		private readonly string[] MovieExtensions = new string[] { ".avi", ".mov", ".mpg", ".mpeg", ".mkv", ".wmv" };

		public IEnumerable<string> CommandNames => new[] { nameof(NextEpisodeOf) };
		private readonly Dictionary<string, string> series = new Dictionary<string, string>
		{
			{ "friends", "Jóbarátok" },
			{ "smallville", null },
			{ "this is us", null },
			{ "american horror story", null },
			{ "supernatural", null },
			{ "legacies", null },
			{ "green archer", null },
		};

		public void Execute()
		{
			var seriesName = FileReader.GetContent(nameof(NextEpisodeOf));
			if (series.ContainsKey(seriesName.ToLower()))
			{
				var newEpisodeFilePath = GetNextFileName(seriesName, series[seriesName.ToLower()]);
				if (File.Exists(newEpisodeFilePath))
				{
					ProcessUtils.Start(Vlc, $"\"{newEpisodeFilePath}\"");
					Thread.Sleep(10000);
					SendKeys.SendWait("f");
					var moviePointerFilename = GetPointerFileName(seriesName);
					File.WriteAllText(moviePointerFilename, $"{newEpisodeFilePath}");
				}
				else
				{
					Reader.ReadAsync($"Can't find next episode of {seriesName}.");
				}
			}
			else
			{
				Reader.ReadAsync($"No data found from {seriesName}.");
			}
		}

		public string GetNextFileName(string seriesName, string alias)
		{
			if (String.IsNullOrEmpty(alias))
			{
				return GetNextFileNameWithSearchPattern(seriesName, GetFileNameSearchPattern(seriesName));
			}

			return GetNextFileNameWithSearchPattern(seriesName, GetFileNameSearchPattern(alias));
		}

		private string GetNextFileNameWithSearchPattern(string seriesName, string fileNameSearchPattern)
		{
			var moviePointerFilename = GetPointerFileName(seriesName);
			if (!File.Exists(moviePointerFilename))
			{
				return FileUtils.SearchForFirst(MoviesFolder, fileNameSearchPattern, MovieExtensions);
			}

			var filename = FileUtils.GetFileContent(moviePointerFilename);
			var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filename));

			var files = directoryInfo.GetFilesWithExtensions("*", SearchOption.TopDirectoryOnly, MovieExtensions);

			var lastFileInfo = files[files.Length - 1];
			if (lastFileInfo.FullName == filename)
			{
				directoryInfo = new DirectoryInfo(lastFileInfo.Directory.Parent.FullName);
				var directories = directoryInfo.GetDirectories();

				var lastDirecoryInfo = directories[directories.Length - 1];
				if (lastDirecoryInfo.FullName == lastFileInfo.Directory.FullName)
				{
					return FileUtils.SearchForFirst(MoviesFolder, fileNameSearchPattern, MovieExtensions);
				}

				for (var i = 0; i < directories.Length - 1; i++)
				{
					if (directories[i].FullName == lastFileInfo.Directory.FullName)
					{
						return FileUtils.SearchForFirst(directories[i + 1].FullName, fileNameSearchPattern, MovieExtensions);
					}
				}
			}
			else
			{
				for (var i = 0; i < files.Length - 1; i++)
				{
					if (files[i].FullName == filename)
					{
						return files[i + 1].FullName;
					}
				}
			}
			return null;
		}

		private string GetPointerFileName(string seriesName)
		{
			return Path.Combine(Application.StartupPath, seriesName.Replace(" ", String.Empty));
		}

		private string GetFileNameSearchPattern(string seriesName)
		{
			var normalizedSeriesName = seriesName.Replace('a', '*')
				.Replace('e', '*')
				.Replace('i', '*')
				.Replace('o', '*')
				.Replace('u', '*')
				.Replace(' ', '*');
			return $"*{normalizedSeriesName}*";
		}
	}
}
