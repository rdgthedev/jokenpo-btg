namespace Jokenpo.Helpers;

public static class ChoiceHelper
{
    public static void InitializeSingletons()
    {
        Rock.Instance.InitWeaknesses();
        Paper.Instance.InitWeaknesses();
        Scissors.Instance.InitWeaknesses();
        Lizard.Instance.InitWeaknesses();
        Spock.Instance.InitWeaknesses();
    }

    public static Dictionary<int, string> GetValidChoices()
    {
        var orderChoice = 1;

        return AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.BaseType == typeof(Choice) && !type.IsAbstract)
            .Select(type => type.Name)
            .ToDictionary(_ => orderChoice++);
    }

    public static Choice GetChoiceByKey(int key)
    {
        const string propertyName = "Instance";

        var validChoices = GetValidChoices();

        if (!validChoices.TryGetValue(key, out var choiceName))
            throw new ArgumentException($"Ocorreu um erro crítico ao buscar a escolha ({key}). Tente novamente.");

        var choiceType = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == choiceName && t.BaseType == typeof(Choice) && !t.IsAbstract);

        if (choiceType is null)
            throw new ArgumentException($"Ocorreu um erro crítico ao buscar a escolha ({key}). Tente novamente.");

        var choiceInstance = choiceType.GetProperty(
            propertyName,
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

        if (choiceInstance is null)
            throw new ArgumentException($"A escolha ({choiceName}) não possui singleton.");

        return (Choice)choiceInstance.GetValue(null)!;
    }
}