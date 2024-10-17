Interpreter Pattern
Definition:
Defines a representation for a grammar along with an interpreter to use that grammar.
Use Case:
Parsing and evaluating mathematical expressions.
Example:
csharp
Copy code
// Abstract Expression
public interface IExpression
{
    int Interpret();
}

// Terminal Expression
public class Number : IExpression
{
    private readonly int _number;

    public Number(int number) => _number = number;

    public int Interpret() => _number;
}

// Non-terminal Expression
public class Add : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public Add(IExpression left, IExpression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }

    public int Interpret() => _leftExpression.Interpret() + _rightExpression.Interpret();
}

// Usage
class Program
{
    static void Main()
    {
        IExpression number1 = new Number(5);
        IExpression number2 = new Number(10);
        IExpression addExpression = new Add(number1, number2);

        Console.WriteLine($"Result: {addExpression.Interpret()}"); // Outputs: Result: 15
    }
}
