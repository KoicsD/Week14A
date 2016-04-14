using System;
using System.Collections.Generic;
using System.IO;

// Exercise 2: File watching

namespace SeekAndArchive
{
    partial class Program
    {
        static List<FileSystemWatcher> watchers;

        static void OnChanged(object source, FileSystemEventArgs e)
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
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
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
    }
}
