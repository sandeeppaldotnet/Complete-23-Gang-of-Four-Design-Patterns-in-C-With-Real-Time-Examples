Singleton Pattern
Definition:
Ensures that a class has only one instance and provides a global point of access to it.
Use Case:
Configuration settings that should be shared across the application.
Example:
csharp
Copy code
// Singleton
public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();

    private ConfigurationManager() { } // Private constructor

    public static ConfigurationManager Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new ConfigurationManager();
            }
        }
    }

    public string GetSetting(string key) => "some value"; // Example method
}

// Usage
class Program
{
    static void Main()
    {
        var config = ConfigurationManager.Instance;
        Console.WriteLine(config.GetSetting("SomeKey"));
    }
}

