Observer Pattern
Definition:
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
Use Case:
Implementing a news feed where users are notified of new articles.
Example:
csharp
Copy code
// Subject Interface
public interface INewsPublisher
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify(string news);
}

// Observer Interface
public interface IObserver
{
    void Update(string news);
}

// Concrete Subject
public class NewsPublisher : INewsPublisher
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void Subscribe(IObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);
    
    public void Notify(string news)
    {
        foreach (var observer in _observers)
        {
            observer.Update(news);
        }
    }
}

// Concrete Observer
public class NewsSubscriber : IObserver
{
    private readonly string _name;

    public NewsSubscriber(string name) => _name = name;

    public void Update(string news) => Console.WriteLine($"{_name} received news: {news}");
}

// Usage
class Program
{
    static void Main()
    {
        var publisher = new NewsPublisher();
        var subscriber1 = new NewsSubscriber("Alice");
        var subscriber2 = new NewsSubscriber("Bob");

        publisher.Subscribe(subscriber1);
        publisher.Subscribe(subscriber2);

        publisher.Notify("Breaking News: Observer Pattern in C#!");
    }
}

