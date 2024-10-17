Command Pattern
Definition:
Encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations.
Use Case:
Implementing an undo functionality in a text editor.
Example:
csharp
Copy code
// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Concrete Command
public class AddTextCommand : ICommand
{
    private readonly Document _document;
    private readonly string _text;

    public AddTextCommand(Document document, string text)
    {
        _document = document;
        _text = text;
    }

    public void Execute() => _document.AddText(_text);
    public void Undo() => _document.RemoveText(_text);
}

// Receiver
public class Document
{
    private readonly StringBuilder _content = new StringBuilder();

    public void AddText(string text) => _content.Append(text);
    public void RemoveText(string text) => _content.Remove(_content.Length - text.Length, text.Length);
    
    public override string ToString() => _content.ToString();
}

// Invoker
public class TextEditor
{
    private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            var command = _commandHistory.Pop();
            command.Undo();
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var document = new Document();
        var textEditor = new TextEditor();

        var command = new AddTextCommand(document, "Hello, World!");
        textEditor.ExecuteCommand(command);
        
        Console.WriteLine(document); // Outputs: Hello, World!

        textEditor.Undo();
        Console.WriteLine(document); // Outputs: (empty)
    }
}
