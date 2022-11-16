namespace Composite;


interface ISystemItem
{
    string? Name { get; set; }
    string? Path { get; set; }
    double Size { get; }
}



class File : ISystemItem
{
    public string? Name { get; set; }
    public string? Path { get; set; }
    public double Size { get; }


    public File(string? name, double size, string? path = "")
    {
        Name = name;
        Path = path;
        Size = size;
    }
}


class Folder : ISystemItem
{
    private readonly List<ISystemItem> _systemItems;

    public Folder(string? name, string? path)
    {
        Name = name;
        Path = path;

        _systemItems = new();
    }

    public string? Name { get; set; }
    public string? Path { get; set; }
    public double Size
    {
        get
        {
            Console.WriteLine(Name);
            return _systemItems.Sum(item => item.Size);
        }
    }


    public void Add(ISystemItem item)
    {
        item.Path = $@"{Path}\{item.Name}";

        _systemItems.Add(item);
    }

    public void Delete(ISystemItem item)
        => _systemItems.Remove(item);

    public List<ISystemItem> GetSystemItems()
        => _systemItems;

}


class Program
{
    static void Main()
    {
        var folderC = new Folder("C", @"C:\");
        var folderProgramFiles = new Folder("Program Files", @"C:\Program Files");
        var folderUsers = new Folder("Users", @"C:\Users");
        var folderAdobe = new Folder("Adobe", @"C:\Program Files\Adobe");
        var folderMicrosoft = new Folder("Microsoft", @"C:\Program Files\Microsoft");



        folderAdobe.Add(new File("AdobeFile1.cs", 1.5));
        folderAdobe.Add(new File("AdobeFile2.txt", 3.2));
        folderMicrosoft.Add(new File("MicrosoftFile.png", 3));
        folderUsers.Add(new File("UsersFile.txt", 2.5));
        folderProgramFiles.Add(new File("ProgramFilesFile.json", 0.5));


        folderProgramFiles.Add(folderAdobe);
        folderProgramFiles.Add(folderMicrosoft);

        folderC.Add(folderProgramFiles);
        folderC.Add(folderUsers);


        Console.WriteLine(folderC.Size);
    }
}



// C:\
// C:\Program Files
// C:\Program Files\Adobe
// C:\Program Files\Microsoft
// C:\Users