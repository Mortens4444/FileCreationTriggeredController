using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FileCreationTriggeredController.Hardware.Display
{
	static class DisplayDevices
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

		private const int WM_SYSCOMMAND = 0x112;
		private const int SC_MONITORPOWER = 0xF170;

		public static void TurnOff()
		{
			var form = new Form();
			SendMessage(form.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2);
			form.Close();
		}
	}
}
