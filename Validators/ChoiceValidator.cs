namespace Jokenpo.Validators;

public static class ChoiceValidator
{
    public static bool Validate(int choiceKey)
        => ChoiceHelper.GetValidChoices().ContainsKey(choiceKey);
}