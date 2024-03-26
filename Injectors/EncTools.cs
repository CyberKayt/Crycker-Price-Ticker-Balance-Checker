namespace DaddyRecoveryBuilder.Injectors
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    internal static class EncTools
    {
        /// <summary>
        /// Compresses the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        internal static string CompressString(string text)
        {
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                var memoryStream = new MemoryStream();
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gZipStream.Write(buffer, 0, buffer.Length);
                }
                memoryStream.Position = 0;
                var compressedData = new byte[memoryStream.Length];
                memoryStream.Read(compressedData, 0, compressedData.Length);
                var gZipBuffer = new byte[compressedData.Length + 4];

                Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
                Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);

                result = Convert.ToBase64String(gZipBuffer);
            }
            catch { }
            return result;
        }
    }
}
