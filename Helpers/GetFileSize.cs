namespace DaddyRecoveryBuilder.Helpers
{
    using System;

    public class GetFileSize
    {
        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string Inizialize(long value)
        {
            if (value < 0) { return $"-{Inizialize(-value)}"; }
            int i = 0, size = 1024; decimal dValue = value;
            while (Math.Round(dValue / size) >= 1) { dValue /= size; i++; }
            return $"{dValue:n1} {SizeSuffixes[i]}";
        }
    }
}