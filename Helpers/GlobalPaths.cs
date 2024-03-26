namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.IO;
    using System.Reflection;

    public static class GlobalPaths
    {
        public static readonly string CurrDir = Environment.CurrentDirectory;
        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string ExeFullPath = Assembly.GetExecutingAssembly().Location;
        public static readonly string ExeFileName = Path.GetFileName(ExeFullPath);

        /// <summary>
        /// Метод для комбинирования путей
        /// </summary>
        /// <param name="path">Имя пути</param>
        /// <returns>Комбинированный путь</returns>
        public static string CombinePath(params string[] path)
        {
            string result = string.Empty;
            try
            {
                result = Path.Combine(path) ?? string.Concat(path);
            }
            catch { }
            return result;
        }
    }
}