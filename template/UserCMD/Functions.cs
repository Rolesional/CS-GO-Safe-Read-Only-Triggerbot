using System;
using System.Runtime.InteropServices;

namespace nextcheat
{
	internal class Functions
	{
		public static IntPtr IntPtrAlloc<T>(T param)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf<T>(param));
			Marshal.StructureToPtr<T>(param, intPtr, false);
			return intPtr;
		}

		public static void IntPtrFree(ref IntPtr preAllocated)
		{
			if (IntPtr.Zero == preAllocated)
			{
				throw new NullReferenceException("Go Home");
			}
			Marshal.FreeHGlobal(preAllocated);
			preAllocated = IntPtr.Zero;
		}
	}
}
