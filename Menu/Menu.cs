namespace Jokenpo.Menu;

public static class Menu
{
    public static void Load()
    {
        try
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=====Menu Principal====\n");
                Console.WriteLine("1 - Iniciar");
                Console.WriteLine("2 - Sair");

                Console.Write("\nDigite o número da sua escolha: ");
                var option = Convert.ToInt32(Console.ReadLine());

                while (option is < 1 or > 2)
                {
                    Console.Clear();
                    Console.Write("\nOpção inválida. Escolha uma opção válida (1 ou 2): ");
                    option = Convert.ToInt32(Console.ReadLine());
                }

                Console.Clear();
                switch (option)
                {
                    case 1:
                        StartMenu();
                        break;
                    case 2:
                        Exit();
                        break;
                }
            }
        }
        catch (ArgumentException e)
        {
            Console.Clear();
            Console.Write($"\n{e.Message}. Você retornará ao menu principal em 3 segundos.");
        }
        catch (Exception)
        {
            Console.Clear();
            Console.Write("\nOcorre um erro interno. Você retornará ao menu principal em 3 segundos.");
        }
        finally
        {
            Thread.Sleep(3000);
            Load();
        }
    }

    private static int ChoiceMenu()
    {
        var validChoices = ChoiceHelper.GetValidChoices();

        Console.WriteLine("\nEscolha uma das opções abaixo: \n");

        foreach (var choice in validChoices)
            Console.WriteLine($"{choice.Key} - {choice.Value}");

        Console.Write("\nDigite o número da sua escolha: ");
        var choiceKey = Convert.ToInt32(Console.ReadLine());

        while (!ChoiceValidator.Validate(choiceKey))
        {
            Console.Clear();
            Console.WriteLine($"\nA escolha '{choiceKey}' é inválida. Escolha uma opção válida abaixo: ");
            ChoiceMenu();

            choiceKey = Convert.ToInt32(Console.ReadLine());
        }

        return choiceKey;
    }

    private static Player PlayerIdentificationMenu(int playerCount)
    {
        Console.Write($"\nDigite o nome do player {playerCount}: ");
        var playerName = Console.ReadLine();

        while (string.IsNullOrEmpty(playerName))
        {
            Console.Clear();
            Console.Write($"\nNome inválido. Digite novamente o nome do player ${playerCount}: ");
            playerName = Console.ReadLine();
        }

        return new Player(playerName);
    }

    private static void StartMenu()
    {
        const int maxPlayers = 2;

        var playersWithChoice = new Dictionary<Player, Choice>();

        for (var playerCount = 1; playerCount <= maxPlayers; playerCount++)
        {
            Console.Clear();

            var player = PlayerIdentificationMenu(playerCount);
            var choiceKey = ChoiceMenu();

            playersWithChoice.Add(player, ChoiceHelper.GetChoiceByKey(choiceKey));
        }

        var result = MoveValidator.ValidateMove(playersWithChoice);

        Console.Clear();
        Console.WriteLine($"\n{result.Message}\n");

        Console.Write("Digite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    private static void Exit()
    {
        Console.Clear();
        Console.WriteLine("\nÉ uma pena que você não queira jogar. Até a próxima!");
        Environment.Exit(0);
    }
}