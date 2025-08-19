namespace Jokenpo.Models;

public class Paper : Choice
{
    private static readonly Lazy<Paper> _paper = new(() => new Paper());
    public static Paper Instance => _paper.Value;

    public Paper() => Name = nameof(Paper);

    public override void InitWeaknesses() => Weaknesses = [Scissors.Instance, Lizard.Instance];
}