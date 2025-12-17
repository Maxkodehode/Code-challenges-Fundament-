using Spectre.Console;

namespace Code_challenges_Fundament_;

class Program
{
    static void Main(string[] args)
    {
        var variables = new Variabler();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green]Hvilke oppgave?[/]")
                .AddChoices("Oppgave: 1", "Oppgave: 2", "Oppgave: 3")
        );
        switch (choice)
        {
            case "Oppgave: 1":
                variables.PopulateArray();
                break;
            case "Oppgave: 2":
                break;
            case "Oppgave: 3":
                break;
        }
    }
}
