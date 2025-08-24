﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RenamingObfuscation.Classes
{
    internal static class DecryptionHelper
    {
        /// <summary>
        /// Method for decrypt string with Base64.
        /// </summary>
        /// <param name="dataEnc">Input encode string</param>
        /// <returns>Plain string</returns>
        /// 

        public static string Decrypt_Base64(string dataEnc)
        {
            try
            {
                var value = Convert.FromBase64String(dataEnc);
                string r = string.Empty;
                if (value != null && value.Length > 0)
                {
                    using (MemoryStream strm = new MemoryStream(value))
                    using (GZipStream zip = new GZipStream(strm, CompressionMode.Decompress))
                    using (StreamReader reader = new StreamReader(zip))
                    {
                        r = reader.ReadToEnd();
                    }
                }

                return r;
            }
            catch
            {
                return null;
            }

        }
    }
}
