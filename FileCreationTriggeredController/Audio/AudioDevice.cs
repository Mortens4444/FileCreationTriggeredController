using System;
using System.Runtime.InteropServices;

namespace FileCreationTriggeredController.Audio
{
	static class AudioDevice
	{
		public static IAudioEndpointVolume GetMasterVolumeHandler()
		{
			IMMDeviceEnumerator deviceEnumerator = null;
			IMMDevice speakers = null;
			try
			{
				deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
				deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);

				var audioEndpointVolume = typeof(IAudioEndpointVolume).GUID;
				speakers.Activate(ref audioEndpointVolume, 0, IntPtr.Zero, out object masterVolume);
				return (IAudioEndpointVolume)masterVolume;
			}
			finally
			{
				if (speakers != null)
				{
					Marshal.ReleaseComObject(speakers);
				}
				if (deviceEnumerator != null)
				{
					Marshal.ReleaseComObject(deviceEnumerator);
				}
			}
		}
	}
}
