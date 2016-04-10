using System;
using System.Collections.Generic;
using System.IO;

namespace SeekAndArchive
{
    class Program
    {
        // static variables:
        static List<FileInfo> filesFound;
        static List<FileSystemWatcher> watchers;

        // methods to process command-line arguments:
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

        // Exercise 1: Searching for a file
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

        // Exercise 2: File watching
        static void OnChangedOrDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + "\t" + e.ChangeType);
        }

        static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: " + e.OldFullPath + "\trenamed to: " + e.FullPath);
        }

        static void initializeWatchers(List<FileInfo> fileList, List<FileSystemWatcher> watcherList)
        {
            foreach (FileInfo file in fileList)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(file.DirectoryName, file.Name);
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Changed += new FileSystemEventHandler(OnChangedOrDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Deleted += new FileSystemEventHandler(OnChangedOrDeleted);
                watcherList.Add(watcher);
            }
        }

        static void listenUntilKeypress(List<FileSystemWatcher> watcherList)
        {
            foreach (FileSystemWatcher watcher in watcherList)
                watcher.EnableRaisingEvents = true;
            Console.WriteLine("Now application is watching specified files.\nPress any key to exit.");
            Console.ReadKey(true);
            foreach (FileSystemWatcher watcher in watcherList)
                watcher.EnableRaisingEvents = false;
        }

        // MAIN
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
