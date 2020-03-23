using System.Threading;

namespace FileCreationTriggeredController
{
	class Program
	{
		static void Main(string[] args)
		{
			FileSystemChangeTrigger.WatchDirectory(@"C:\Users\morte\OneDrive\FCTC");

			while (true)
			{
				Thread.Sleep(100);
			}
		}
	}
}
