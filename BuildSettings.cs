namespace DaddyRecoveryBuilder
{
    // Класс свойств
    public static class BuildSettings
    {
        // Functions Frm
        public static bool Virtual_Machine { get; set; } = false;
        public static bool CIS_Country { get; set; } = false;
        public static bool Anti_Dump { get; set; } = false;
        public static bool String_Encrypt { get; set; } = false; 
        public static bool Output_Console { get; set; } = false;
        public static bool Output_WinForm{ get; set; } = false;
        public static bool Self_Delete { get; set; } = false;
        public static bool Active_Logger { get; set; } = false;

        // Assembly Frm
        public static bool Icon_Build { get; set; } = false;
        public static bool Assembly_Build { get; set; } = false;

        public static string Pictures_Build { get; set; }
    }
}