Chain of Responsibility Pattern
Definition:
Allows passing requests along a chain of handlers. Each handler can either process the request or pass it to the next handler in the chain.
Use Case:
Handling multiple levels of logging (info, warning, error) where each level can choose to log the message or pass it along.
Example:
csharp
Copy code
// Handler Interface
public abstract class Logger
{
    protected Logger NextLogger;

    public void SetNext(Logger nextLogger) => NextLogger = nextLogger;

    public void LogMessage(string message, LogLevel level)
    {
        if (CanHandle(level))
        {
            Handle(message);
        }
        else
        {
            NextLogger?.LogMessage(message, level);
        }
    }

    protected abstract bool CanHandle(LogLevel level);
    protected abstract void Handle(string message);
}

// Concrete Handlers
public class InfoLogger : Logger
{
    protected override bool CanHandle(LogLevel level) => level == LogLevel.Info;

    protected override void Handle(string message) => Console.WriteLine($"Info: {message}");
}

public class ErrorLogger : Logger
{
    protected override bool CanHandle(LogLevel level) => level == LogLevel.Error;

    protected override void Handle(string message) => Console.WriteLine($"Error: {message}");
}

// Log Level Enum
public enum LogLevel
{
    Info,
    Error
}

// Usage
class Program
{
    static void Main()
    {
        var infoLogger = new InfoLogger();
        var errorLogger = new ErrorLogger();

        infoLogger.SetNext(errorLogger);

        infoLogger.LogMessage("This is an information message.", LogLevel.Info);
        infoLogger.LogMessage("This is an error message.", LogLevel.Error);
    }
}
