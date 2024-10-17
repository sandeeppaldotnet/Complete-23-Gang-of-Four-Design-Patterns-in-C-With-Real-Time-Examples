Mediator Pattern
Definition:
Defines an object that encapsulates how a set of objects interact. Promotes loose coupling by keeping objects from referring to each other explicitly.
Use Case:
Managing interactions between different components in a chat application.
Example:
csharp
Copy code
// Mediator Interface
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void RegisterUser(User user);
}

// Concrete Mediator
public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new List<User>();

    public void RegisterUser(User user) => _users.Add(user);

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            // Message should not be sent to the user who sent it
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

// Colleague
public class User
{
    private readonly string _name;
    private readonly IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        _name = name;
        _mediator = mediator;
        _mediator.RegisterUser(this);
    }

    public void Send(string message) => _mediator.SendMessage(message, this);

    public void Receive(string message) => Console.WriteLine($"{_name} received: {message}");
}

// Usage
class Program
{
    static void Main()
    {
        var mediator = new ChatMediator();
        var user1 = new User("Alice", mediator);
        var user2 = new User("Bob", mediator);

        user1.Send("Hello Bob!");
        user2.Send("Hi Alice!");
    }
}
