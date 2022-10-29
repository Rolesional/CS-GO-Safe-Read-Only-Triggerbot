using System;
using System.Runtime.InteropServices;

namespace nextcheat
{

	internal class WinAPI
	{
		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SendMessageA(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
	}
}
