using System;
using System.Collections.Generic;
using System.IO;

// MAIN

namespace SeekAndArchive
{
    partial class Program
    {
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

        
        static void Main(string[] args)
        {
            // processing command-line arguments
            string fileName, directoryName;
            if (!TryParseArgs(args, out fileName, out directoryName))
                return;
            DirectoryInfo rootDir;
            if (!TryParseDirName(directoryName, out rootDir))
                return;

            // Exercise 1
            filesFound = new List<FileInfo>();
            SearchRecursively(fileName, rootDir, filesFound);
            listFiles(filesFound);

            // Exercise 2
            watchers = new List<FileSystemWatcher>();
            initializeWatchers(filesFound, watchers);
            listenUntilKeypress(watchers);
        }
    }
}
