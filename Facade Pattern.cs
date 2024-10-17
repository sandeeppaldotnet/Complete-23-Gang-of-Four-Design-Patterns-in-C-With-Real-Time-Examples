Facade Pattern
Definition:
Provides a simplified interface to a complex subsystem.
Use Case:
Providing a unified interface to a set of interfaces in a subsystem, like a home theater system.
Example:
csharp
Copy code
// Subsystem Classes
public class Amplifier
{
    public void On() => Console.WriteLine("Amplifier is on.");
    public void Off() => Console.WriteLine("Amplifier is off.");
}

public class DVDPlayer
{
    public void Play(string movie) => Console.WriteLine($"Playing {movie}.");
}

// Facade
public class HomeTheaterFacade
{
    private readonly Amplifier _amplifier;
    private readonly DVDPlayer _dvdPlayer;

    public HomeTheaterFacade(Amplifier amplifier, DVDPlayer dvdPlayer)
    {
        _amplifier = amplifier;
        _dvdPlayer = dvdPlayer;
    }

    public void WatchMovie(string movie)
    {
        _amplifier.On();
        _dvdPlayer.Play(movie);
    }

    public void EndMovie()
    {
        _amplifier.Off();
    }
}

// Usage
class Program
{
    static void Main()
    {
        var amplifier = new Amplifier();
        var dvdPlayer = new DVDPlayer();
        var homeTheater = new HomeTheaterFacade(amplifier, dvdPlayer);

        homeTheater.WatchMovie("Inception");
        homeTheater.EndMovie();
    }
}
