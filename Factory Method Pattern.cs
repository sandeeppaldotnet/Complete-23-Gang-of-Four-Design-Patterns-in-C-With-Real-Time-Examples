Factory Method Pattern
Definition:
Defines an interface for creating an object, but lets subclasses alter the type of objects that will be created.
Use Case:
Logging frameworks that can produce different types of logs (e.g., file, console).
Example:
csharp
Copy code
// Product Interface
public interface ILogger
{
    void Log(string message);
}

// Concrete Products
public class FileLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"Logging to file: {message}");
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"Logging to console: {message}");
}

// Creator
public abstract class LoggerFactory
{
    public abstract ILogger CreateLogger();
}

// Concrete Creators
public class FileLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger() => new FileLogger();
}

public class ConsoleLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger() => new ConsoleLogger();
}

// Client Code
class Program
{
    static void Main()
    {
        LoggerFactory factory = new ConsoleLoggerFactory();
        ILogger logger = factory.CreateLogger();
        logger.Log("This is a log message.");
    }
}

