﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace roles
{
    public class memory
    {

        #region imports

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

        #endregion

        #region procstuff
        public Process proc;
        public Process GetProcess(string procname)
        {
            proc = Process.GetProcessesByName(procname)[0]; 
            return proc;
        }
        public IntPtr GetModuleBase(string modulename)
        {
            if (modulename.Contains(".exe")) 
                return proc.MainModule.BaseAddress;

           foreach (ProcessModule module in proc.Modules)
            {
                if (module.ModuleName == modulename)
                    return module.BaseAddress;
            }
            return IntPtr.Zero;
        }
        #endregion

        #region readpointer
        public IntPtr ReadPointer(IntPtr addy)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(proc.Handle,addy, buffer, buffer.Length, IntPtr.Zero);
            return new IntPtr(BitConverter.ToInt32(buffer, 0));
        }

        public IntPtr ReadPointer(IntPtr addy, int offset)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(proc.Handle, IntPtr.Add(addy,offset), buffer, buffer.Length, IntPtr.Zero);

            return new IntPtr(BitConverter.ToInt32(buffer, 0));
        }
        #endregion 

        #region readbytes
        public byte[] ReadBytes(IntPtr addy,int bytes)
        {
            byte[] buffer = new byte[bytes];
            ReadProcessMemory(proc.Handle, addy,buffer, buffer.Length, IntPtr.Zero);
            return buffer;
        }
        public byte[] ReadBytes(IntPtr addy,int offset, int bytes)
        {
            byte[] buffer = new byte[bytes];
            ReadProcessMemory(proc.Handle, IntPtr.Add(addy,offset), buffer, buffer.Length, IntPtr.Zero);
            return buffer;
        }

        #endregion
    }
}
