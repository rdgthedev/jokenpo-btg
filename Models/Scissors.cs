namespace Jokenpo.Models;

public class Scissors : Choice
{
    private static readonly Lazy<Scissors> _scissors = new(() => new Scissors());
    public static Scissors Instance => _scissors.Value;
    
    public override void InitWeaknesses() => Weaknesses = [Rock.Instance, Spock.Instance];

}