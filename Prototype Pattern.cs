Prototype Pattern
Definition:
Creates new objects by copying an existing object, known as the prototype.
Use Case:
Cloning complex objects, like game characters with various attributes.
Example:
csharp
Copy code
// Prototype Interface
public interface ICloneable
{
    ICloneable Clone();
}

// Concrete Prototype
public class GameCharacter : ICloneable
{
    public string Name { get; set; }
    public int Health { get; set; }

    public ICloneable Clone() => new GameCharacter { Name = this.Name, Health = this.Health };
}

// Usage
class Program
{
    static void Main()
    {
        GameCharacter original = new GameCharacter { Name = "Hero", Health = 100 };
        GameCharacter clone = (GameCharacter)original.Clone();
        
        Console.WriteLine($"Original: {original.Name}, Health: {original.Health}");
        Console.WriteLine($"Clone: {clone.Name}, Health: {clone.Health}");
    }
}
