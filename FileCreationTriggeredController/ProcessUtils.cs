using System.Diagnostics;

namespace FileCreationTriggeredController
{
	public static class ProcessUtils
	{
		public static Process Start(string path, string parameters = null)
		{
			return parameters != null ? Process.Start(path, parameters) : Process.Start(path);
		}
	}
}
