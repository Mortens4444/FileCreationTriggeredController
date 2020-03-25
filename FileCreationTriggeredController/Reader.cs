using System;
using System.Speech.Synthesis;
using System.Threading;

namespace FileCreationTriggeredController
{
	public static class Reader
	{
		private static readonly Random random;
		private static readonly SpeechSynthesizer reader;

		static Reader()
		{
			random = new Random(DateTime.Now.Millisecond);
			reader = new SpeechSynthesizer();
		}

		public static void ReadAsync(params string[] choices)
		{
			if (choices.Length < 1) return;
			var thread = new Thread(() =>
			{
				if (choices.Length > 1)
				{
					var choice = random.Next(0, choices.Length);
					reader.SpeakAsync(choices[choice]);
				}
				else
				{
					reader.SpeakAsync(choices[0]);
				}
			})
			{ IsBackground = true };
			thread.Start();
		}

		public static void Read(params string[] choices)
		{
			if (choices.Length < 1)
			{
				return;
			}

			if (choices.Length > 1)
			{
				var choice = random.Next(0, choices.Length);
				reader.Speak(choices[choice]);
			}
			else
			{
				reader.Speak(choices[0]);
			}
		}

		public static void StopReading()
		{
			reader.SpeakAsyncCancelAll();
		}
	}
}
