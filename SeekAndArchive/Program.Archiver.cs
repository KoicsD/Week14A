//using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SeekAndArchive
{
    partial class Program
    {
        static List<DirectoryInfo> archiveDirs;

        static void CreateDirectories(string dest)
        {
            archiveDirs = new List<DirectoryInfo>();
            if (!dest.EndsWith(Path.DirectorySeparatorChar.ToString()))
                dest += Path.DirectorySeparatorChar;
            for (int i = 0; i < filesFound.Count; ++i)
            {
                archiveDirs.Add(Directory.CreateDirectory(dest + "archive" + i.ToString()));
            }
        }

        static void ArchiveFile(FileInfo src, DirectoryInfo dest)
        {
            using (FileStream inputStream = src.Open(FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputStream = File.Create(dest.FullName + Path.DirectorySeparatorChar + src.Name + ".gz"))
                {
                    using (GZipStream compressorStream = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        inputStream.CopyTo(compressorStream);
                    }
                }
            }
        }

        static void IdentifyAndArchive(object sender)
        {
            FileSystemWatcher currentWatcher = (FileSystemWatcher)sender;
            int index = watchers.IndexOf(currentWatcher);
            ArchiveFile(filesFound[index], archiveDirs[index]);
        }
    }
}
