namespace Jokenpo.Result;

public class Result
{
    public string Message { get; private set; }

    private Result(string message) => Message = message;

    public static Result Tie(string message) => new(message);
    public static Result Win(string message) => new(message);
}