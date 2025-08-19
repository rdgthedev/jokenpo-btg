namespace Jokenpo.Result;

public class Result
{
    public EMoveResult MoveResult { get; private set; }
    public string Message { get; private set; }

    private Result(EMoveResult moveResult, string message)
    {
        MoveResult = moveResult;
        Message = message;
    }

    public static Result Tie(string message) => new(EMoveResult.Tie, message);
    public static Result Win(string message) => new(EMoveResult.Win, message);
}