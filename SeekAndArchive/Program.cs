using System;
using System.Collections.Generic;
using System.IO;

// MAIN

namespace SeekAndArchive
{
    partial class Program
    {
        static bool TryParseArgs(string[] args, out string fileName, out string dirWathced, out string archiveDir)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("This application has to be run with 2 command-line arguments, respectively:");
                Console.WriteLine("\t* a filename to search for");
                Console.WriteLine("\t* a directory name to search in");
                Console.WriteLine("\t* a directory to save archive into");
                fileName = null;
                dirWathced = null;
                archiveDir = null;
                return false;
            }
            fileName = args[0];
            dirWathced = args[1];
            archiveDir = args[2];
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
            string fileName, dirWatched, archiveDir;
            if (!TryParseArgs(args, out fileName, out dirWatched, out archiveDir))
                return;
            DirectoryInfo rootDir;
            if (!TryParseDirName(dirWatched, out rootDir))
                return;

            // Exercise 1
            filesFound = new List<FileInfo>();
            SearchRecursively(fileName, rootDir, filesFound);
            listFiles(filesFound);

            // Exercise 2
            watchers = new List<FileSystemWatcher>();
            initializeWatchers(filesFound, watchers);
            CreateDirectories(archiveDir);
            listenUntilKeypress(watchers);
        }
    }
}
