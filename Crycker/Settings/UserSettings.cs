using Crycker.Helper;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Crycker.Settings
{
    public class UserSettings
    {
        private const string SettingsFile = @"Crycker.config";
        private static string SettingsPathname; 

        public string Provider { get; set; }
        public string Coin { get; set; }
        public string Currency { get; set; }
        public int RefreshInterval { get; set; }
        public int PercentageNotification { get; set; }

        [DefaultValue(true)]
        public bool Highlight { get; set; }
        [DefaultValue(true)]
        public bool DarkMode { get; set; }

        [DefaultValue("Segoe UI")]
        public string FontName { get; set; }
        [DefaultValue(7)]
        public float FontSize { get; set; }
        [DefaultValue(true)]
        public bool FontStyleBold { get; set; }


        [DefaultValue(false)]
        public bool Log { get; set; }
        [DefaultValue(true)]
        public bool CheckForUpdates { get; set; }

        public UserSettings()
        {
            SettingsPathname = Path.Combine(Application.StartupPath, SettingsFile);
            Logger.Info($"Settings file {SettingsPathname}");

            Provider = "Bitstamp";
            Coin = "BTC";
            Currency = "EUR";
            RefreshInterval = 300;
            PercentageNotification = 0;

            Highlight = true;
            DarkMode = true;

            FontName = "Segoe UI";
            FontSize = 7;
            FontStyleBold = true;

            Log = false;
            CheckForUpdates = true;
        }        

        public static UserSettings Load()
        {
            var settings = new UserSettings();

            if (!File.Exists(SettingsPathname)) return settings;

            var stream = new FileStream(SettingsPathname, FileMode.Open, FileAccess.Read, FileShare.Read);

            var xmlSerializer = new XmlSerializer(typeof(UserSettings));
            settings = (UserSettings)xmlSerializer.Deserialize(stream);
            stream.Close();

            return settings;
        }

        public void Save()
        {
            var xmlSerializer = new XmlSerializer(typeof(UserSettings));
            var stream = new StreamWriter(SettingsPathname);

            xmlSerializer.Serialize(stream, this);
            stream.Close();
        }        
    }
}