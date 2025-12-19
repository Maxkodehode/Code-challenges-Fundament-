using Code_challenges_Fundament_.Oppgaver.Oppgave1;
using Code_challenges_Fundament_.Oppgaver.Oppgave2;
using Code_challenges_Fundament_.Oppgaver.Oppgave3;
using Spectre.Console;

namespace Code_challenges_Fundament_;

class Program
{
    static void Main(string[] args)
    {
        var variables = new Variabler();
        var calculator = new FirstInput();
        var collections = new Collections();
        string? errorMessage = null;
        bool showMenu = true;

        while (showMenu)
        {
            AnsiConsole.Clear();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                AnsiConsole.MarkupLine($"[red]Error: {errorMessage}[/]\n");
                errorMessage = null;
            }

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Hvilke oppgave?[/]")
                    .AddChoices("Oppgave: 1", "Oppgave: 2", "Oppgave: 3", "Exit")
            );
            switch (choice)
            {
                case "Oppgave: 1":
                    variables.PopulateArray();
                    break;
                case "Oppgave: 2":
                    calculator.Run();
                    break;
                case "Oppgave: 3":
                    collections.Run();
                    break;
                case "Exit":
                    showMenu = false;
                    break;
            }
        }
    }
}
