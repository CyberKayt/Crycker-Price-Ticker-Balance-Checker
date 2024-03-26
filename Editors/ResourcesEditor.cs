namespace DaddyRecoveryBuilder.Editors
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using dnlib.DotNet;

    public static class ResourcesEditor
    {
        /// <summary>
        /// Метод добавляющий ресурсы в билд файл
        /// </summary>
        /// <param name="name">Имя ресурса</param>
        /// <returns></returns>
        public static byte[] ResoucesData(Dictionary<string, object> name)
        {
            using var ms = new MemoryStream();
            using IResourceWriter Writer = new ResourceWriter(ms);
            foreach (KeyValuePair<string, object> listresource in name)
            {
                // Добавляем имя и значения ресурса
                Writer.AddResource(listresource.Key, listresource.Value);
            }
            Writer.Generate(); // Записываем все ресурсы
            return ms?.ToArray(); // Возвращаем массив со всеми записанными ресурсами
        }

        /// <summary>
        ///  Метод для получения имени ресурса приложения
        /// </summary>
        /// <param name="data">Модуль для загрузки</param>
        /// <returns>Имя ресурса приложения</returns>
        public static string ResName(byte[] data)
        {
            string result = string.Empty;
            try
            {
                using var md = ModuleDefMD.Load(data); // Загрузка модуля
                foreach (dnlib.DotNet.Resource ss in md.Resources.Where(ss => ss.Name.Contains("Properties")))
                {
                    result = ss.Name;
                }
            }
            catch { }
            return result;
        }
    }
}