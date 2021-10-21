using System;
using System.Collections.Generic;
using System.IO;

namespace WordFinder
{

    class FileAccess
    {
        private static readonly Lazy<FileAccess> lazy = new Lazy<FileAccess>(() => new FileAccess());
        private FileAccess()
        {

        }

        internal static FileAccess GetFileAccess()
        {
            return lazy.Value;
        }

        internal string[] GetAllItems(string path)
        {
            return File.ReadAllLines(path);
        }

        internal void WriteToFile(string path, List<string> allLines)
        {
            File.WriteAllLines(path, allLines.ToArray());
        }

        internal bool CheckFileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
