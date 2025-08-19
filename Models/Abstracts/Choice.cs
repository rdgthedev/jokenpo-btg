namespace Jokenpo.Models.Abstracts;

public abstract class Choice
{
    public string Name { get; protected set; } = string.Empty;
    public List<Choice> Weaknesses { get; protected set; } = null!;

    public abstract void InitWeaknesses();
}