Proxy Pattern
Definition:
Provides a surrogate or placeholder for another object to control access to it.
Use Case:
Controlling access to a resource that is expensive to create, such as a large image or database connection.
Example:
csharp
Copy code
// Subject Interface
public interface IImage
{
    void Display();
}

// Real Subject
public class RealImage : IImage
{
    private readonly string _filename;

    public RealImage(string filename) => _filename = filename;

    public void Display() => Console.WriteLine($"Displaying {_filename}");
}

// Proxy
public class ProxyImage : IImage
{
    private readonly string _filename;
    private RealImage _realImage;

    public ProxyImage(string filename) => _filename = filename;

    public void Display()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_filename);
        }
        _realImage.Display();
    }
}

// Usage
class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("my_picture.jpg");
        image.Display(); // Loads and displays the image
        image.Display(); // Displays the image without reloading
    }
}
