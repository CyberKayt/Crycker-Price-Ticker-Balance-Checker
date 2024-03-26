using Crycker.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Crycker.Helper
{
    public static class Logger
    {
        private static string logFilename = "crycker-log.txt";

        private static bool _enabled;
        public static bool Enabled {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                if (value) Debug.WriteLine($"Will log to {LogPathName()}");
            }
        }

        private static string LogPathName()
        {
            return Path.Combine(Application.StartupPath, logFilename);
        }

        static Logger()
        {
            var settings = UserSettings.Load();
            Enabled = settings.Log;            
        }

        public static void Error(string message)
        {
            Log("ERROR", message);
        }

        public static void Error(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Error(string message, Exception ex)
        {
            Error($"{message} - {ex.Message}");
        }

        public static void Warning(string message)
        {
            Log("WARN", message);
        }

        public static void Warning(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Warning(string message, Exception ex)
        {
            Error($"{message} - {ex.Message}");
        }

        public static void Info(string message)
        {            
            Log("INFO", message);
        }

        public static void Info(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Info(string message, Exception ex)
        {
            Error($"{message} - {ex.Message}");
        }

        public static void Log(string level, string message)
        {
            var logText = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{level}] {message}";
            
            Debug.WriteLine(logText);

            try
            {
                if (Enabled)
                    File.AppendAllText(LogPathName(), logText + Environment.NewLine);
            }
            catch
            {                
                Debug.WriteLine($"Whaaaaat? Log cannot be written to {LogPathName()}.");
            }
        }
    }
}