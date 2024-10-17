Strategy Pattern
Definition:
Defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it.
Use Case:
Sorting a collection of items using different sorting strategies.
Example:
csharp
Copy code
// Strategy Interface
public interface ISortStrategy
{
    void Sort(List<int> list);
}

// Concrete Strategies
public class BubbleSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Sorting using Bubble Sort");
        // Bubble sort implementation
    }
}

public class QuickSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Sorting using Quick Sort");
        // Quick sort implementation
    }
}

// Context
public class Sorter
{
    private ISortStrategy _strategy;

    public void SetStrategy(ISortStrategy strategy) => _strategy = strategy;

    public void Sort(List<int> list) => _strategy.Sort(list);
}

// Usage
class Program
{
    static void Main()
    {
        var sorter = new Sorter();
        var numbers = new List<int> { 5, 2, 8, 3, 1 };

        sorter.SetStrategy(new BubbleSort());
        sorter.Sort(numbers);

        sorter.SetStrategy(new QuickSort());
        sorter.Sort(numbers);
    }
}
