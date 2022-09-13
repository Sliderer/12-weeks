using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve_weeks.Saving
{
    internal class FilesController
    {
        private static readonly string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static async void WriteFile(string text, string fileName)
        {
            await File.WriteAllTextAsync(Path.Combine(basePath, fileName), text);
        }

        public static async void AppendFile(string text, string fileName)
        {
            await File.AppendAllTextAsync(Path.Combine(basePath, fileName), text);
        }

        public static string ReadFile(string fileName)
        {
            return File.ReadAllTextAsync(Path.Combine(basePath, fileName)).Result;
        }

        public static string[] ReadFileLines(string fileName)
        {
            return File.ReadAllLinesAsync(Path.Combine(basePath, fileName)).Result;
        }

        public static void DeleteFile(string fileName)
        {
            File.Delete(Path.Combine(basePath, fileName));
        }

        public static void CheckFile(string filename)
        {
            if (!File.Exists(basePath + "/" + filename))
            {
                File.Create(Path.Combine(basePath, filename));
            }
        }

    }
}
