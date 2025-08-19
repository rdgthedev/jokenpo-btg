namespace Jokenpo.Models;

public class Spock : Choice
{
    private static readonly Lazy<Spock> _spock = new(() => new Spock());
    public static Spock Instance => _spock.Value;

    public Spock() => Name = nameof(Spock);

    public override void InitWeaknesses() => Weaknesses = [Paper.Instance, Lizard.Instance];
}