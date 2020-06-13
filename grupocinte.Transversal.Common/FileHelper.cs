using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace grupocinte.Transversal.Common
{
    public static class FileHelper
    {
        public static string ToBase64(Stream data)
        {
            StreamReader reader = new StreamReader(data);

            byte[] bytedata = System.Text.Encoding.Default.GetBytes(reader.ReadToEnd());

            return Convert.ToBase64String(bytedata);
        }

        public static Stream ToStream(string base64Data)
        {
            byte[] streamBytes = Convert.FromBase64String(base64Data);
            MemoryStream ms = new MemoryStream(streamBytes, 0, streamBytes.Length);

            return ms;
        }

        public static string GetUniqueFileName(string filePath)
        {
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string path = Path.GetDirectoryName(filePath);
            string newFullPath = filePath;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }

            return newFullPath;
        }
    }
}
