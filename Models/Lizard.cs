namespace Jokenpo.Models;

public class Lizard : Choice
{
    private static readonly Lazy<Lizard> _lizard = new(() => new Lizard());
    public static Lizard Instance => _lizard.Value;

    public Lizard() => Name = nameof(Lizard);

    public override void InitWeaknesses() => Weaknesses = [Scissors.Instance, Rock.Instance];
}