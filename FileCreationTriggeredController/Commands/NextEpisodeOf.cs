using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileCreationTriggeredController.Utils;

namespace FileCreationTriggeredController.Commands
{
	class NextEpisodeOf : ICommand
	{
		private readonly string MoviesFolder = @"D:\";
		private readonly string Vlc = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe";

		public IEnumerable<string> CommandNames => new[] { nameof(NextEpisodeOf) };
		private readonly Dictionary<string, string> series = new Dictionary<string, string>
		{
			{ "smallville", "Smallville.mvp" },
			{ "this is us", "ThisIsUs.mvp" }
		};

		public void Execute()
		{
			var seriesName = FileReader.GetContent(nameof(NextEpisodeOf));
			if (series.ContainsKey(seriesName.ToLower()))
			{
				var newEpisodeFilePath = GetNextFileName(seriesName);
				if (File.Exists(newEpisodeFilePath))
				{
					ProcessUtils.Start(Vlc, $"\"{newEpisodeFilePath}\"");
					Thread.Sleep(3000);
					SendKeys.SendWait("f");
				}
				else
				{
					Reader.ReadAsync($"Can't find next episode of {seriesName}.");
				}

				var moviePointerFilename = Path.Combine(Application.StartupPath, series[seriesName]);
				File.WriteAllText(moviePointerFilename, $"{newEpisodeFilePath}");
			}
			else
			{
				Reader.ReadAsync($"No data found from {seriesName}.");
			}
		}

		public string GetNextFileName(string seriesName)
		{
			var fileNameSearchPattern = GetFileNameSearchPattern(seriesName);
			var moviePointerFilename = Path.Combine(Application.StartupPath, series[seriesName]);
			if (!File.Exists(moviePointerFilename))
			{
				return FileUtils.SearchForFirst(MoviesFolder, fileNameSearchPattern);
			}

			var filename = FileUtils.GetFileContent(moviePointerFilename);
			var di = new DirectoryInfo(Path.GetDirectoryName(filename));
			var files = di.GetFiles();

			var lastFileInfo = files[files.Length - 1];
			if (lastFileInfo.FullName == filename)
			{
				di = new DirectoryInfo(lastFileInfo.Directory.Parent.FullName);
				var directories = di.GetDirectories();

				var lastDirecoryInfo = directories[directories.Length - 1];
				if (lastDirecoryInfo.FullName == lastFileInfo.Directory.FullName)
				{
					return FileUtils.SearchForFirst(MoviesFolder, fileNameSearchPattern);
				}

				for (var i = 0; i < directories.Length - 1; i++)
				{
					if (directories[i].FullName == lastFileInfo.Directory.FullName)
					{
						return FileUtils.SearchForFirst(directories[i + 1].FullName, fileNameSearchPattern);
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

		private string GetFileNameSearchPattern(string seriesName)
		{
			var normalizedSeriesName = seriesName.Replace('a', '*')
				.Replace('e', '*')
				.Replace('i', '*')
				.Replace('o', '*')
				.Replace('u', '*');
			return $"*{normalizedSeriesName}*.avi";
		}
	}
}
