namespace Jokenpo.Result;

public class Result
{
    public string PlayerName { get; private set; } = string.Empty;
    public bool IsSuccess { get; private set; }
    public EMoveResult MoveResult { get; private set; }
    public string Message { get; private set; }

    private Result(string playerName, EMoveResult moveResult, string message, bool isSuccess = false)
    {
        PlayerName = playerName;
        MoveResult = moveResult;
        IsSuccess = isSuccess;
        Message = message;
    }

    private Result(EMoveResult moveResult, string message, bool isSuccess = false)
    {
        MoveResult = moveResult;
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Failure(string playerName, string message) => new(playerName, EMoveResult.Lose, message);
    public static Result Success(string playerName, string message) => new(playerName, EMoveResult.Win, message, true);
    public static Result Success(string message) => new(EMoveResult.Tie, message, true);
}