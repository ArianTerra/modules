using File_Manager_Task;

IHistorySaver historySaver = new XmlHistorySaver();
FileManager fileManager = new (historySaver);

string input = "";
PrintFiles();

while (input != "exit")
{
    Console.Write("\nFileManager " + fileManager.Path + "> ");
    input = Console.ReadLine();

    var inputArgs = input.Split(' ', 2);

    if (inputArgs[0] == "open" || inputArgs[0] == "cd")
    {
        if (inputArgs.Length < 2)
        {
            Console.WriteLine("[!] Not enough arguments provided");
            continue;
        }

        OpenFileOrDirectory(inputArgs[1]);
    }

    if (inputArgs[0] == "ls")
    {
        PrintFiles();
    }

    if (inputArgs[0] == "sort")
    {
        if (inputArgs.Length < 2)
        {
            Console.WriteLine("[!] Not enough arguments provided");
            continue;
        }

        if (inputArgs[1] == "filename") // this is aliases for FileSystemInfo properties
        {
            SortPrintFiles("Name");
        }
        else if (inputArgs[1] == "created")
        {
            SortPrintFiles("CreationTime");
        }
        else if (inputArgs[1] == "modified")
        {
            SortPrintFiles("LastWriteTime");
        }
        else // you can also sort by any property type of FileSystemInfo, just write its name
        {
            SortPrintFiles(inputArgs[1]);
        }
    }
}

void PrintFiles()
{
    Console.WriteLine("FILES: ");
    try
    {
        foreach (var file in fileManager.GetDirectoryContent())
        {
            Console.WriteLine(file);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("[!] " + e.Message);
    }
}

void SortPrintFiles(string category)
{
    Console.WriteLine("SORTED FILES: ");
    try
    {
        foreach (var file in fileManager.GetDirectoryContent(category))
        {
            Console.WriteLine(file);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("[!] " + e.Message);
    }
}

void OpenFileOrDirectory(string path)
{
    try
    {
        if (Directory.Exists(path))
        {
            fileManager.Path = path;
        }
        else if (File.Exists(path))
        {
            Console.WriteLine(FileManager.ReadFile(path, 500));
        }
        else
        {
            Console.WriteLine("[!] File or directory does not exits");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("[!] " + e.Message);
    }
}