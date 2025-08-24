using Server.RenamingObfuscation.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RenamingObfuscation.Classes
{
    public class Base64
    {
        /// <summary>
        /// Method for encrypt string with Base64. 
        /// </summary>
        /// <param name="dataPlain">Input plain string</param>
        /// <returns>Encode string</returns>
        /// 

        // Шифруем строки StrCrypt.Encrypt(
        public static string Encrypt(string value)
        {
            try
            {
                byte[] numArray = new byte[0];
                if (!string.IsNullOrEmpty(value))
                {
                    numArray = Encoding.UTF8.GetBytes(value);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                            gzipStream.Write(numArray, 0, numArray.Length);
                        numArray = memoryStream.ToArray();
                    }
                }
                return Convert.ToBase64String(numArray);
            }
            catch { return null; }
        }
 
    }
}
