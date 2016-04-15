using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    partial class Program
    {
        static void ReadDemo(IsolatedStorageFile storeFile)
        {
            string[] fileNames = storeFile.GetFileNames("UserSetting.set");
            if (fileNames.Length == 0)
            {
                Console.WriteLine("No files can be found with name 'UserSetting.set'");
                return;
            }
            foreach (string fileName in fileNames)
            {
                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, storeFile))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string content = reader.ReadToEnd();
                        Console.WriteLine("Content of '{0}':", fileName);
                        Console.WriteLine(content);
                    }
                }
            }
        }
    }
}
