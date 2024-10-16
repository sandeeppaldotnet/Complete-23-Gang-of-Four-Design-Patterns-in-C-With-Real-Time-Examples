Adapter Pattern
Definition:
Allows incompatible interfaces to work together by wrapping one interface with another.
Use Case:
Integrating third-party libraries into an existing codebase.
Example:
csharp
Copy code
// Target Interface
public interface ITarget
{
    void Request();
}

// Adaptee
public class Adaptee
{
    public void SpecificRequest() => Console.WriteLine("Specific request from Adaptee.");
}

// Adapter
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee) => _adaptee = adaptee;

    public void Request() => _adaptee.SpecificRequest();
}

// Usage
class Program
{
    static void Main()
    {
        Adaptee adaptee = new Adaptee();
        ITarget adapter = new Adapter(adaptee);
        adapter.Request(); // Outputs: Specific request from Adaptee.
    }
}
