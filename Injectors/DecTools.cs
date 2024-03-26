namespace DaddyRecoveryBuilder.Injectors
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    internal static class DecTools
    {
        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        internal static string DecompressString(string compressedText)
        {
            string result = string.Empty;
            try
            {
                byte[] gZipBuffer = Convert.FromBase64String(compressedText);
                using var memoryStream = new MemoryStream();
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);
                var buffer = new byte[dataLength];
                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }
                result = Encoding.UTF8.GetString(buffer);
            }
            catch { }
            return result;
        }
    }
}
