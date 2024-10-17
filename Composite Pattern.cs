Composite Pattern
Definition:
Composes objects into tree structures to represent part-whole hierarchies.
Use Case:
Building a file system where directories can contain files and subdirectories.
Example:
csharp
Copy code
// Component
public interface IFileSystemComponent
{
    void ShowInfo();
}

// Leaf
public class File : IFileSystemComponent
{
    private string _name;

    public File(string name) => _name = name;

    public void ShowInfo() => Console.WriteLine($"File: {_name}");
}

// Composite
public class Directory : IFileSystemComponent
{
    private string _name;
    private List<IFileSystemComponent> _children = new List<IFileSystemComponent>();

    public Directory(string name) => _name = name;

    public void Add(IFileSystemComponent component) => _children.Add(component);
    public void ShowInfo()
    {
        Console.WriteLine($"Directory: {_name}");
        foreach (var child in _children)
        {
            child.ShowInfo();
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var root = new Directory("Root");
        var file1 = new File("File1.txt");
        var file2 = new File("File2.txt");

        var subDir = new Directory("SubDirectory");
        subDir.Add(new File("SubFile1.txt"));

        root.Add(file1);
        root.Add(file2);
        root.Add(subDir);

        root.ShowInfo();
    }
}
