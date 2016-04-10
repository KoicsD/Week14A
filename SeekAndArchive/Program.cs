using System;
using System.Collections.Generic;
using System.IO;

namespace SeekAndArchive
{
    class Program
    {
        static List<FileInfo> filesFound;

        static bool TryParseArgs(string[] args, out string fileName, out string directoryName)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("This application has to be run with 2 command-line arguments, respectively:");
                Console.WriteLine("\t* a filename to search for");
                Console.WriteLine("\t* a directory name to search in");
                fileName = null;
                directoryName = null;
                return false;
            }
            fileName = args[0];
            directoryName = args[1];
            return true;
        }

        static bool TryParseDirName(string directoryName, out DirectoryInfo directory)
        {
            directory = new DirectoryInfo(directoryName);
            if (!directory.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                Console.WriteLine("Directory name: " + directoryName);
                return false;
            }
            return true;
        }

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

        static void Main(string[] args)
        {
            string fileName, directoryName;
            if (!TryParseArgs(args, out fileName, out directoryName))
                return;
            DirectoryInfo rootDir;
            if (!TryParseDirName(directoryName, out rootDir))
                return;

            filesFound = new List<FileInfo>();
            SearchRecursively(fileName, rootDir, filesFound);
            listFiles(filesFound);
        }
    }
}
