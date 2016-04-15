using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    partial class Program
    {
        static void WriteDemo(IsolatedStorageFile storeFile)
        {
            using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("UserSetting.set", FileMode.Create, storeFile))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("This is my beautiful piece of settings.");
                }
            }
        }
    }
}
