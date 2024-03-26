using Microsoft.Win32;
using System.Reflection;

namespace Crycker.Helper
{
    public class AutoRunHelper
    {
        static RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public static bool Get()
        {
            return registryKey.GetValue(Assembly.GetEntryAssembly().GetName().Name) != null;
        }

        public static void Set()
        {
            registryKey.SetValue(Assembly.GetEntryAssembly().GetName().Name, Assembly.GetExecutingAssembly().Location);            
        }

        public static void Clear()
        {
            registryKey.DeleteValue(Assembly.GetEntryAssembly().GetName().Name);
        }
    }
}
