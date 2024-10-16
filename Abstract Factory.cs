// Abstract Factory
public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factory for Windows
public class WindowsUIFactory : IUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

// Concrete Factory for Mac
public class MacUIFactory : IUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Abstract Products
public interface IButton { void Render(); }
public interface ICheckbox { void Render(); }

// Concrete Products
public class WindowsButton : IButton
{
    public void Render() => Console.WriteLine("Rendering Windows Button.");
}

public class MacButton : IButton
{
    public void Render() => Console.WriteLine("Rendering Mac Button.");
}

public class WindowsCheckbox : ICheckbox
{
    public void Render() => Console.WriteLine("Rendering Windows Checkbox.");
}

public class MacCheckbox : ICheckbox
{
    public void Render() => Console.WriteLine("Rendering Mac Checkbox.");
}

// Client Code
public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Render()
    {
        _button.Render();
        _checkbox.Render();
    }
}

// Usage
class Program
{
    static void Main()
    {
        IUIFactory factory = new WindowsUIFactory();
        Application app = new Application(factory);
        app.Render();
    }
}
