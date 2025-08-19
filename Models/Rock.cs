namespace Jokenpo.Models;

public class Rock : Choice
{
    private static readonly Lazy<Rock> _rock = new(() => new Rock());
    public static Rock Instance => _rock.Value;

    public Rock() => Name = nameof(Rock);

    public override void InitWeaknesses() => Weaknesses = [Paper.Instance, Spock.Instance];
}