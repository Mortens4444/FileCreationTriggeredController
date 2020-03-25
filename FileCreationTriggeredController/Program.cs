using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace FileCreationTriggeredController
{
	class Program
	{
		[DllImport("Kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("User32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private const int Hide = 0;

		public static string WatcherDirectory;

		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				HaltWithError(1, "Only one parameter is required, which must be a directory, where the files will be created.");
			}

			WatcherDirectory = String.Join(" ", args);
			if (!Directory.Exists(WatcherDirectory))
			{
				HaltWithError(2, $"The following directory does not exists: {WatcherDirectory}");
			}

#if !DEBUG
			var handle = GetConsoleWindow();
			ShowWindow(handle, Hide);
#endif

			FolderCleaner.Clean(WatcherDirectory);
			FileSystemChangeTrigger.WatchDirectory(WatcherDirectory);

			while (true)
			{
				Thread.Sleep(100);
			}
		}

		private static void HaltWithError(int errorCode, string errorMessage)
		{
			Console.Error.WriteLine(errorMessage);
			Console.ReadKey();
			Environment.Exit(errorCode);
		}
	}
}
