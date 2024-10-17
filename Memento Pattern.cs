Memento Pattern
Definition:
Captures and externalizes an object's internal state without violating encapsulation, allowing the object to be restored to this state later.
Use Case:
Implementing an undo feature in a text editor.
Example:
csharp
Copy code
// Memento
public class TextMemento
{
    public string Text { get; }

    public TextMemento(string text) => Text = text;
}

// Originator
public class TextEditor
{
    private string _text;

    public void Write(string text) => _text = text;

    public TextMemento Save() => new TextMemento(_text);

    public void Restore(TextMemento memento) => _text = memento.Text;

    public override string ToString() => _text;
}

// Caretaker
public class Caretaker
{
    private readonly Stack<TextMemento> _mementos = new Stack<TextMemento>();

    public void Save(TextEditor editor) => _mementos.Push(editor.Save());
    public void Undo(TextEditor editor)
    {
        if (_mementos.Count > 0)
        {
            editor.Restore(_mementos.Pop());
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var caretaker = new Caretaker();

        editor.Write("Version 1");
        caretaker.Save(editor);

        editor.Write("Version 2");
        Console.WriteLine(editor); // Outputs: Version 2

        caretaker.Undo(editor);
        Console.WriteLine(editor); // Outputs: Version 1
    }
}
