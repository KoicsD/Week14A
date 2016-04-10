using System;
using System.Collections.Generic;
using System.IO;

namespace SeekAndArchive
{
    class Program
    {
        static List<FileInfo> filesFound = new List<FileInfo>();

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

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("This application has to be run with 2 command-line arguments, respectively:");
                Console.WriteLine("\t* a filename to search for");
                Console.WriteLine("\t* a directory name to search in");
                return;
            }
            string fileName = args[0];
            string directoryName = args[1];

            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                Console.WriteLine("Directory name: " + directoryName);
                return;
            }

            SearchRecursively(fileName, rootDir, filesFound);

            Console.WriteLine("{0} files found:", filesFound.Count);
            foreach (FileInfo file in filesFound)
            {
                Console.WriteLine("\t" + file.FullName);
            }
        }
    }
}
