namespace DaddyRecoveryBuilder
{
    using System.Collections.Generic;

    public static class Collector
    {
        /// <summary>
        /// Словарь для хранения данных
        /// </summary>
        public static Dictionary<string, string> BuildPairs = new Dictionary<string, string>();

        /// <summary>
        /// Метод для добавления данных в словарь
        /// </summary>
        /// <param name="fromText"></param>
        /// <param name="toText"></param>
        /// <returns></returns>
        public static bool AddToDic(string fromText, string toText)
        {
            // Проверяем значение словаря
            if (!BuildPairs.ContainsKey(fromText))
            {
                // Если нет, добавляем в словарь
                BuildPairs.Add(fromText, toText);
                return true;
            }
            else
            {
                // Если есть, просто обновляем словарь
                BuildPairs[fromText] = toText;
                return true;
            }
        }
    }
}
