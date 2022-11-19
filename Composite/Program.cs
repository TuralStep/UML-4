using System.Text;

namespace Composite;


interface SystemItem
{
    string? Name { get; set; }
    string? Path { get; set; }
    double Size { get; }
}



class File : SystemItem
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


class Folder : SystemItem
{
    List<SystemItem> _systemItems;
    private static StringBuilder _tab = new("");

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
            //Console.WriteLine(Name);
            return _systemItems.Sum(item => item.Size);
        }
    }


    public void Add(SystemItem item)
    {
        item.Path = $@"{Path}\{item.Name}";

        _systemItems.Add(item);
    }

    public void Delete(SystemItem item)
        => _systemItems.Remove(item);

    public List<SystemItem> GetSystemItems()
        => _systemItems;


    public void ShowFolderInside()
    {
        Console.WriteLine(Name);

        _tab.Append("  ");
        foreach (var f in _systemItems)
        {
            if (f is Folder)
            {
                Console.Write(_tab.ToString());
                (f as Folder).ShowFolderInside();
            }
            else if (f is File)
            {
                Console.WriteLine(_tab.ToString() + f.Name);
            }
        }
        _tab.Remove(_tab.Length - 2, 2);
    }

}


class Program
{
    static void Main()
    {
        Folder folderC = new Folder("C", @"C:\");
        Folder folderProgramFiles = new Folder("Program Files", @"C:\Program Files");
        Folder folderUsers = new Folder("Users", @"C:\Users");
        Folder folderAdobe = new Folder("Adobe", @"C:\Program Files\Adobe");
        Folder folderMicrosoft = new Folder("Microsoft", @"C:\Program Files\Microsoft");



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
        folderC.ShowFolderInside();

    }
}