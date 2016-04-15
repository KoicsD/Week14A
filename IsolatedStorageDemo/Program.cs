using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    partial class Program
    {
        static void Main(string[] args)
        {
            using (IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                WriteDemo(userStore);
                ReadDemo(userStore);
            }
        }
    }
}
