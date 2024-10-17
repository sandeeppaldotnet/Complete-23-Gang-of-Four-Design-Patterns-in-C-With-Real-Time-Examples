Flyweight Pattern
Definition:
Reduces the cost of creating and manipulating a large number of similar objects.
Use Case:
Managing a large number of graphic objects like characters in a game.
Example:
csharp
Copy code
// Flyweight
public class Character
{
    private readonly char _symbol;

    public Character(char symbol) => _symbol = symbol;

    public void Display(int x, int y) => Console.WriteLine($"Character: {_symbol} at ({x}, {y})");
}

// Flyweight Factory
public class CharacterFactory
{
    private readonly Dictionary<char, Character> _characters = new Dictionary<char, Character>();

    public Character GetCharacter(char symbol)
    {
        if (!_characters.ContainsKey(symbol))
        {
            _characters[symbol] = new Character(symbol);
        }
        return _characters[symbol];
    }
}

// Usage
class Program
{
    static void Main()
    {
        var factory = new CharacterFactory();
        string text = "Hello World";

        foreach (var c in text)
        {
            var character = factory.GetCharacter(c);
            character.Display(0, 0); // Simplified position for this example
        }
    }
}
