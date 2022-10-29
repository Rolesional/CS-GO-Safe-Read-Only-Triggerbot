	using System;
using System.Runtime.InteropServices;

namespace nextcheat
{
	internal class UserCMD
	{
		public static void Execute(string command)
		{
			IntPtr hWnd = WinAPI.FindWindowA("Valve001", null);
			IntPtr lpData = Marshal.StringToHGlobalAnsi(command);
			IntPtr lParam = Functions.IntPtrAlloc<Structs.COPYDATASTRUCT>(new Structs.COPYDATASTRUCT
			{
				dwData = IntPtr.Zero,
				lpData = lpData,
				cbData = command.Length + 1
			});
			WinAPI.SendMessageA(hWnd, 74, IntPtr.Zero, lParam);
			Functions.IntPtrFree(ref lParam);
			Functions.IntPtrFree(ref lpData);
		}
	}
}
