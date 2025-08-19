namespace Jokenpo.Result;

public class Result
{
    public bool IsSuccess { get; private set; }
    public EMoveResult MoveResult { get; private set; }
    public string Message { get; private set; }

    private Result(EMoveResult moveResult, string message, bool isSuccess = false)
    {
        MoveResult = moveResult;
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Failure(string message) => new(EMoveResult.Lose, message);
    public static Result Success(string message) => new(EMoveResult.Win, message, true);
    public static Result Tie(string message) => new(EMoveResult.Tie, message, true);
}