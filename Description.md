## Objectives of the week

This week you will learn about collections and IO.  
Collection classes are specialized classes for data storage and retrieval. These classes provide support for stacks, queues, lists, and hash tables. Most collection classes implement the same interfaces.  
Collection classes serve various purposes, such as allocating memory dynamically to elements and accessing a list of items on the basis of an index etc. These classes create collections of objects of the Object class, which is the base class for all data types in C#.  
A file is a collection of data stored in a disk with a specific name and a directory path. When a file is opened for reading or writing, it becomes a **stream**.  
The stream is basically the sequence of bytes passing through the communication path. There are two main streams: the **input stream** and the **output stream**. The **input stream** is used for reading data from file (read operation) and the **output stream** is used for writing into the file (write operation).  

--------

The learning plan is this week is the following:

![](Description/LearningPlan.png)

--------

Recommended learning material is the following:

Collections  
https://msdn.microsoft.com/en-us/library/ybcx56wz.aspx

IO  
https://msdn.microsoft.com/en-us/library/2kzb96fk.aspx

--------

--------

## Collections

**Exercise 1: Create and Use a Queue**

In this exercise, you will create a queue, add items to it, and empty the queue to the console window. 

***Step by step***

1. Create a new console application called **SequentialCollections**. 

2. In the main code file, include (or import for Visual Basic) the System.Collections namespace. 

3. In the **Main** method of the project, create a new instance of the **Queue** class. 

4. Add four strings to the new collection: “First”, “Second”, “Third”, and “Fourth”. 

5. Empty the queue, one item at a time, using the Count property to test whether the collection is empty. Your resulting code might look something like this: 

```C#
using System.Collections; 

class Program 
{ 
 static void Main(string[] args) 
 { 
  Queue queue = new Queue(); 
  queue.Enqueue("First"); 
  queue.Enqueue("Second"); 
  queue.Enqueue("Third"); 
  queue.Enqueue("Fourth"); 

  while (queue.Count > 0) 
  { 
    object obj = queue.Dequeue(); 
    Console.WriteLine("From Queue: {0}", obj); 
  } 
 } 
}
```

6. Build the project, and resolve any errors. Verify that the console application successfully runs and shows the items in the queue, in first-in, first-out order. 

**Exercise 2: Create and Use a Stack**

In this exercise, you will create a stack, add items to it, and empty the stack to the console window. 

***Step by step***

1. Open the console application you created in Exercise 1, called **SequentialCollections**. 

2. After the Queue code, create a new instance of the **Stack** class. 

3. Add four strings to the stack: “First”, “Second”, “Third”, and “Fourth”. 

4. Empty the queue, one item at a time, using the Count property to test whether the collection is empty. Your resulting code might look something like this: 

```C#
Stack stack = new Stack(); 
stack.Push("First"); 
stack.Push("Second"); 
stack.Push("Third"); 
stack.Push("Fourth"); 

while (stack.Count > 0) 
{ 
 object obj = stack.Pop(); 
 Console.WriteLine("From Stack: {0}", obj);
}
```

5. Build the project, and resolve any errors. Verify that the console application successfully runs and shows that the items in the stack are in reverse order of the queue’s items (that is, in last-in, first-out order)

**Exercise 3: Create a Lookup Table**

In this exercise, you will create a lookup table for a series of numbers, parse through the digits of a string, and display the numbers in the console. 

***Step by step***

1. Create a new console application called DictionaryCollections. 

2. In the main code file, include (or import for Visual Basic) the System.Collections namespace. 

3. In the Main method of the project, create a new instance of the Hashtable class. 

4. Add items into the new instance of the Hashtable class where the key is a string containing the numbers zero through nine, and the value is the spelled-out name of the numbers zero through nine. 

5. Next create a string variable with a series of numbers in it. 

6. Go through the string, one character at a time using a foreach construct.  

7. Within the foreach, create a new string from the character variable you created in the foreach loop. 

8. Check to see whether the Hashtable contains the key of the single character string. 

9. If it does, get the value for the key from the Hashtable and show it in the console. Your code might look something like this: 

```C#
using System.Collections; 

class Program 
{ 
 static void Main(string[] args) 
 { 
  Hashtable lookup = new Hashtable(); 
  lookup["0"] = "Zero"; 
  lookup["1"] = "One"; 
  lookup["2"] = "Two"; 
  lookup["3"] = "Three"; 
  lookup["4"] = "Four"; 
  lookup["5"] = "Five"; 
  lookup["6"] = "Six"; 
  lookup["7"] = "Seven"; 
  lookup["8"] = "Eight"; 
  lookup["9"] = "Nine"; 

  string ourNumber = "888-555-1212"; 

  foreach (char c in ourNumber) 
  { 
    string digit = c.ToString(); 
    if (lookup.ContainsKey(digit)) 
    { 
      Console.WriteLine(lookup[digit]); 
    } 
  }
 }
}
```

10. Build the project, and resolve any errors. Verify that the console application successfully spells out all the digits in the number you specified. 

**Exercise 4: Create a ListCollection**

In this exercise, you will create a lookup table for country names. The keys will be in Spanish. 

***Step by step***

1. Create a new console application called LookupCollections. 

2. In the main code file, include (or import for Visual Basic) the System.Collections, System.Collections.Specialized, and System.Globalization namespaces. 

3. In the Main method of the project, create a new instance of the ListDictionary class, specifying case insensitive and culture invariant. 

4. Add three lookups to the collection, specifying “Estados Unidos” for “United States”, “Canadá” for “Canada”, and “España” for “Spain. 

5. Write out to the console the values for the Spanish versions of Spain and Canada. Your code should look something like this: 

```C#
using System.Globalization; 
using System.Collections; 
using System.Collections.Specialized; 

class Program 
{ 
 static void Main(string[] args) 
 { 
 // Make the dictionary case insensitive 
 ListDictionary list = new ListDictionary(new  CaseInsensitiveComparer(CultureInfo.InvariantCulture)); 

 // Add some items
 list["Estados Unidos"] = "United States of America"; 
 list["Canadá"] = "Canada"; 
 list["España"] = "Spain"; 

 // Show the results 
 Console.WriteLine(list["españa"]); 
 Console.WriteLine(list["CANADÁ"]); 
 Console.Read();
 }
}
```

6. Build the project, and resolve any errors. Verify that the console application successfully shows both Spain and Canada. 

**Exercise 5: Create a Generic Collection to Store State Data**

In this exercise, you create a generic Dictionary to hold state abbreviations with their full names. 

***Step by step***

1. Create a new console application called GenericCollections. 

2. In the Main method of the project, create a new instance of the generic Dictionary class, specifying the key to be an integer and the value to be a string. 

3. Add items to the collection using country codes for the keys and country names as the values. 

4. Try to add strings for the keys of the country codes to make sure that the Dictionary is type safe. If they fail to compile, remove them in code or comment them out. 

5. Write out to the console of one of your country codes using the indexer syntax of the Dictionary. 

6. Iterate over the collection, and write out the country code and name of the country for each KeyValuePair in the Dictionary. Your code might look something like this: 

```C#
class Program 
{ 
 static void Main(string[] args) 
 { 
  Dictionary<int, String> countryLookup = new Dictionary<int, String>(); 

  countryLookup[44] = "United Kingdom"; 
  countryLookup[33] = "France"; 
  countryLookup[31] = "Netherlands"; 
  countryLookup[55] = "Brazil"; 

  Console.WriteLine("The 33 Code is for: {0}", countryLookup[33]); 

  foreach (KeyValuePair<int, String> item in countryLookup) 
  { 
    int code = item.Key; 
    string country = item.Value; 
    Console.WriteLine("Code {0} = {1}", code, country); 
  }

  Console.Read(); 
 }
}
```

7. Build the project, and resolve any errors. Verify that the console application successfully shows all the countries added.

--------

--------

## IO

**Exercise 1: Searching for a file**

***Task***

Using Visual Studio, create a new console application project. Name the project SeekAndArchive. We would like to create an application which watches a selected group of files, and automatically creates a compressed archive of them when any of them changes.  
As a first step we would like to provide some searching functionality. Let the application have two command arguments: the first is the file we are looking for, and the second is the directory we must perform the recursive searching.  
As an output, list the path of the files found matching the name.  

***Hint***

Use DirectoryInfo and FileInfo (why is it better?). Write a recursive algorithm that traverse all the subdirectories and matches the file names to the search criteria.  
To set up command arguments, right click to the project in the Solution Explorer, then configure command arguments (separated by spaces) for debugging:  

![](Description/visual_studio_project_properties.jpg)  
![](Description/setup_cmd_arg.jpg)

***Advanced task***

Let the user define search patterns, like a*.txt

***Step by step***

1. First we need to examine if the given directory exists at all. We assume that there are two command arguments for the sake of simplicity. You need to add the System.IO namespace to your project as well: 

```C#
static void Main(string[] args) 
{ 
 string fileName = args[0]; 
 string directoryName = args[1]; 
 FoundFiles = new List<FileInfo>(); 

 //examine if the given directory exists at all 
 DirectoryInfo rootDir = new DirectoryInfo(directoryName); 
 if (!rootDir.Exists) 
 { 
 Console.WriteLine("The specified directory does not exist.");
 return;
 }
}
```

Where FoundFiles is declared as a static List outside the main function: 

```C#
static List<FileInfo> FoundFiles; 
```

2. Now we define a new method named RecursiveSearch with the following signature: 

```C#
static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
{ 

}
```

3. The first part of the method should enumerate all the files in the current directory, and append them to the list if their name is the same we are looking for. 

```C#
foreach (FileInfo fil in currentDirectory.GetFiles())
{ 
 if (fil.Name == fileName) 
   foundFiles.Add(fil);
}
```

4. For a recursive search we need to call the same method for all the subdirectories from the current path. 

```C#
 //continue the search recursively 
foreach (DirectoryInfo dir in currentDirectory.GetDirectories()) 
{ 
 RecursiveSearch(foundFiles, fileName, dir); 
}
```

5. Now all we have to do is to call this method from the main method, and list the results for the user. 

```C#
static void Main(string[] args) 
{ 
... 

 //search recursively for the mathing files 
 RecursiveSearch(FoundFiles, fileName, rootDir); 

 //list the found files 
 Console.WriteLine("Found {0} files.", FoundFiles.Count); 

 foreach (FileInfo fil in FoundFiles) 
 { 
   Console.WriteLine("{0}", fil.FullName); 
 }

 Console.ReadKey();
}
```

**Exercise 2: File watching**

***Task***

Use the application you created in the previous execise. Create a filewatcher (or filewatchers) which watches if any of the found files gets modified. Display a message on the console if any modification happens to these files. (now we only watch content changes, and assume for simplicity that the files are not deleted.) 

***Hint***

You might need several FileSystemWatcher objects. 

***Advanced Task***

Watch also if the files are being deleted or renamed, and update the file list accordingly. So if a file is deleted, remove it from the watching list, and also remove its file watcher. 

***Step by step***

1. We will need a list of FileSystemWatcher objects. In the Program class, create the following static variable. 

```C#
static List<FileSystemWatcher> watchers;
```

2. Initialize it in the main method. 
```C#
watchers = new List<FileSystemWatcher>();
```

3. Now for each file, create a corresponding watcher. The watcher should fire if the file has been changed. First of all we need to create a new method which handles the change events. 
```C#
static void WatcherChanged(object sender, FileSystemEventArgs e) 
{ 
 if(e.ChangeType == WatcherChangeTypes.Changed) 
   Console.WriteLine("{0} has been changed!", e.FullPath); 
}
```

4. Create the watchers for each file, and configure them. 

```C#
foreach (FileInfo fil in FoundFiles) 
{ 
 FileSystemWatcher newWatcher = new FileSystemWatcher(fil.DirectoryName, fil.Name); 
 newWatcher.Changed += new FileSystemEventHandler(WatcherChanged); 

 newWatcher.EnableRaisingEvents = true; 
 watchers.Add(newWatcher); 
}
```

**Exercise 3: Automatically create archives**

***Task***

Now continue from exercise 2. Create a custom directory for your archives, and do the following: if any of the files on your list is modified, automatically perform archivation by compressing the file into your temporary directory.

***Hint***

Use a different directory for each file since they have the same name. 

***Advanced Task***

Since you are archiving files, use individual names for your archives. This could be done by adding an increment to the file name, like file1.gz, file2.gz, etc. Or by concatenating the time to the end of the filename. The Path class can make this task easier. 

***Step by step***

1. For simplicity we would like to store a list of separate directories for each monitored file. Declare a static list of DirectoryInfos in the scope of the Program class: 

```C#
static List<DirectoryInfo> archiveDirs;
```

2. At the end of the main function (after the creation of the FileSystemWatchers) create a new archive directory for each file. Insert the following code for example: 

```C#
archiveDirs = new List<DirectoryInfo>(); 

//create archive directories 
for (int i = 0; i < FoundFiles.Count; i++) 
{ 
 archiveDirs.Add(Directory.CreateDirectory("archive" + 
 i.ToString())); 
}
```

3. Add a new method to the Program class, named ArchiveFile. The input of this method will be a FileInfo to archive, and the DirectoryInfo of the target directory. You will need to use the System.IO.Compression namespace. The method will compress the file into the directory. 

```C#
static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive) 
{ 
 FileStream input = fileToArchive.OpenRead(); 
 FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz"); 

 GZipStream Compressor = new GZipStream(output, CompressionMode.Compress); 

 int b = input.ReadByte(); 

 while (b != -1) 
 { 
   Compressor.WriteByte((byte)b); 
   b = input.ReadByte(); 
 } 

 Compressor.Close(); 
 input.Close(); 
 output.Close(); 
}
```

4. Now we need a little trick. It’s not elegant but it will do now. We will modify the code of the new WatcherChanged event handler. First we identify the sender of the event. This will determine, which file has been changed. After that we find the index of that file, and call the previous ArchiveFile method on them. 

```C#
static void WatcherChanged(object sender, FileSystemEventArgs e) 
{ 
 Console.WriteLine("{0} has been changed!", e.FullPath); 

 //find the the index of the changed file 
 FileSystemWatcher senderWatcher = (FileSystemWatcher)sender; 
 int index = watchers.IndexOf(senderWatcher, 0); 

 //now that we have the index, we can archive the file 
 ArchiveFile(archiveDirs[index], FoundFiles[index]); 
}
```

**Exercise 4: Creating a File in Isolated Storage**

In this exercise, you will create a new file in isolated storage. 

1. Create a new console application named IsolatedStorageDemo. 

2. Add an Import (or an using in C#) for the System.IO and System.IO.IsolatedStorage namespaces into the new project.

3. In the Main method of the new project, create a new instance of the IsolatedStorageFile object named userStore that is scoped to the current user and assembly. Your code might look something like this: 

```C#
IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
```

4. Create a new instance of the IsolatedStorageFileStream object, passing in the name UserSettings.set and the new store, as shown in this example: 

```C#
IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStore);
```

5. Use a StreamWriter to write some data into the new stream, and close the writer when finished. Your code might look something like this: 

```C#
StreamWriter userWriter = new StreamWriter(userStream);
userWriter.WriteLine("User Prefs"); 
userWriter.Close();
```

6. Build the project and resolve any errors. Verify that the console application created the new compressed file by checking the file in the file system. The file will exist in a directory under <userFolder>\AppData\Local\IsolatedStorage. This directory is a cache directory, so you will find some machine-generated directory names. You should find the files if you dig deeper into the AssemFiles directory. 

**Exercise 5: Reading a File in Isolated Storage**

In this exercise, you will read the file you created in Exercise 4. 

1. Open the project you created in Exercise 4 (IsolatedStorageDemo). 

2. After the code from Exercise 4, add code to check whether the file exists in the store and show a console message if no files were found. Your code might look something like this: 

```C#
string[] files = userStore.GetFileNames("UserSettings.set"); 
if (files.Length == 0) 
{ 
// ... 
}
```

3. If the file was found, create a new IsolatedStorageFileStream object that opens the file you created in Exercise 1. Create a StreamReader to read all the text in the file into a new local string variable. Your code might look something like this: 

```C#
userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStore); 
StreamReader userReader = new StreamReader(userStream);
string contents = userReader.ReadToEnd();
```

4. Add a line to the console that shows the string you created from the StreamReader.

5. Build the project and resolve any errors. Verify that the console application shows the contents of the file on the command line.

--------

--------

## Summary

The FileSystemInfo classes (FileInfo and DirectoryInfo) can be used to navigate the
file system and get information about files and directories, including size, time stamps, names, attributes, and so on.  
* The File class provides a jumping-off point to creating or opening files in the file
  system.
* The FileStream class can be used to stream data into or out of the file system.
* The StreamReader and StreamWriter classes are instrumental in dealing with
  moving data into and out of streams, including FileStreams, MemoryStreams, and
  IsolatedStorageFileStreams.
* The .NET Framework supports two classes for compressing data: the GZipStream class and the DeflateStream class.
* Isolated storage provides a safe place to keep data about a specific assembly,
  user, or application. Because isolated storage requires so few security rights, it is
  the best way to store data without having to grant an application with permissive
  rights to a user’s system.
