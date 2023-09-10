namespace Banco;

internal static class UIManager
{
    public static void Run(IDictionary<int, IOptionCommand> menuOptions, int exitOption)
    {
        int optionSelected = 0;

        do
        {
            try
            {
                Console.Clear();

                Console.WriteLine("""
                     _____                 
                    | __  |___ ___ ___ ___ 
                    | __ -| .'|   |  _| . |
                    |_____|__,|_|_|___|___|
                    
                """);

                foreach (var optionMenu in menuOptions)
                {
                    Console.WriteLine($"{optionMenu.Key} - {optionMenu.Value.Display}");
                }

                Console.Write("\nSelecione uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out optionSelected) ||
                    !menuOptions.Select(o => o.Key).Contains(optionSelected))
                    throw new Exception("Opção inválida!");

                Console.Clear();

                menuOptions[optionSelected].Execute();
            }
            catch (Exception e)
            {
                optionSelected = -1;

                var corDefault = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"\nErro: {e.Message}");

                Console.ForegroundColor = corDefault;

                Thread.Sleep(2_000);
            }

        } while (optionSelected != exitOption);

    }

    public static void PressKeyToContinue()
    {
        Console.Write("\n\nPressione qualquer tecla para continuar... ");

        Console.ReadKey();
    }
}
