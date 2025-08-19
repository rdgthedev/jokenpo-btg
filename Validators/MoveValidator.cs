namespace Jokenpo.Validators;

public static class MoveValidator
{
    public static Result.Result ValidateMove(Dictionary<Player, Choice> playersWithChoice)
    {
        var firstPlayer = playersWithChoice.First();
        var secondPlayer = playersWithChoice.Last();

        if (playersWithChoice.First().Value.Name == playersWithChoice.Last().Value.Name)
            return Result.Result.Tie("Empate! Ambos os jogadores escolheram a mesma opção.");

        return secondPlayer.Value.Weaknesses.Any(w => w.Name == firstPlayer.Value.Name)
            ? Result.Result.Win($"Parabéns {firstPlayer.Key.Name}, você venceu!")
            : Result.Result.Win($"Parabéns {secondPlayer.Key.Name}, você venceu!");
    }
}