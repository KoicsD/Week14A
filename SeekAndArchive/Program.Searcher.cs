using System;
using System.Collections.Generic;
using System.IO;

// Exercise 1: Searching for a file

namespace SeekAndArchive
{
    partial class Program
    {
        static List<FileInfo> filesFound;

        static void SearchRecursively(string fileName, DirectoryInfo rootDir, List<FileInfo> destFileList)
        {
            foreach (FileInfo file in rootDir.GetFiles())
            {
                if (file.Name == fileName)  // Advanced TODO: enable search pattern
                {
                    destFileList.Add(file);
                }
            }

            foreach (DirectoryInfo directory in rootDir.GetDirectories())
            {
                SearchRecursively(fileName, directory, destFileList);
            }
        }

        static void listFiles(List<FileInfo> fileList)
        {
            Console.WriteLine("{0} files found:", fileList.Count);
            foreach (FileInfo file in fileList)
            {
                Console.WriteLine("\t" + file.FullName);
            }
        }
    }
}
