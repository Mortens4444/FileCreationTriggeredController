using System;
using System.Text;

namespace FileCreationTriggeredController
{
	static class ExceptionDetails
	{
		public static string Get(Exception ex)
		{
			var result = new StringBuilder();
			do
			{
				result.Insert(0, $"{ex}{Environment.NewLine}{Environment.NewLine}");
				ex = ex.InnerException;
			}
			while (ex != null);
			return result.ToString();
		}
	}
}
