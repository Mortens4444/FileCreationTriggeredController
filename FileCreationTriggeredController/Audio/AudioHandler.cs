using System;
using System.Runtime.InteropServices;

namespace FileCreationTriggeredController.Audio
{
	static class AudioHandler
	{
		public static void SetMute(bool isMuted)
		{
			var masterVolumeHandler = AudioDevice.GetMasterVolumeHandler();
			if (masterVolumeHandler != null)
			{
				masterVolumeHandler.SetMute(isMuted, Guid.Empty);
				Marshal.ReleaseComObject(masterVolumeHandler);
			}
		}

		public static void SetMasterVolume(int percent)
		{
			if (percent < 0 || percent > 100)
			{
				throw new ArgumentException("Out of range", nameof(percent));
			}
			var masterVolumeHandler = AudioDevice.GetMasterVolumeHandler();
			if (masterVolumeHandler != null)
			{
				masterVolumeHandler.SetMasterVolumeLevelScalar((float)percent / 100, Guid.Empty);
				Marshal.ReleaseComObject(masterVolumeHandler);
			}
		}
	}
}
