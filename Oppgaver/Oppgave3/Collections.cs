using Spectre.Console;

namespace Code_challenges_Fundament_.Oppgaver.Oppgave3;

public class Collections
{
    private void PrintList<T>(string title, IEnumerable<T> collection, string color = "white")
    {
        AnsiConsole.MarkupLine($"[{color}]{title}:[/]");
        string joined = string.Join(", ", collection);
        AnsiConsole.MarkupLine($"  [white]{joined}[/]\n");
    }

    public void Run()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6 };
        double[] decimals = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
        string[] fastFoods = { "Pizza", "Burger", "Fries", "Taco" };

        List<int> numbersList = new List<int>(numbers);
        List<double> decimalsList = new List<double>(decimals);
        List<string> fastFoodsList = new List<string>(fastFoods);

        var names = new Dictionary<string, string>();
        var isEven = new Dictionary<int, bool>();
        var isDouble = new Dictionary<double, double>();

        //Dictionary string
        names.Add("Alice", "Johnson");
        names.Add("Bob", "Smith");
        names.Add("Charlie", "Davis");
        names.Add("Diana", "Rodriguez");

        //Dictionary int bool
        isEven.Add(2, true);
        isEven.Add(5, false);
        isEven.Add(10, true);

        //Dictionary double
        isDouble.Add(2.7, 4.3);
        isDouble.Add(4.666, 8.67);
        isDouble.Add(8.456, 16.89);

        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[yellow]Oppgave 3: Collections[/]\n");

            PrintList("Numbers Array", numbers, "bold fuchsia");
            PrintList("Decimals Array", decimals, "bold fuchsia");
            PrintList("Fast Foods Array", fastFoods, "bold fuchsia");

            PrintList("Numbers List", numbersList, "bold orange3");
            PrintList("Decimals List", decimalsList, "bold orange3");
            PrintList("Fast Foods List", fastFoods, "bold orange3");

            var grid = new Grid().AddColumn();

            foreach (var entry in names)
            {
                grid.AddRow($"[green]{entry.Key}[/] [grey]->[/] [white]{entry.Value}[/]");
            }

            foreach (var entry in isEven)
            {
                grid.AddRow($"[green]{entry.Key}[/] [grey]->[/] [white]{entry.Value}[/]");
            }

            foreach (var entry in isDouble)
            {
                grid.AddRow($"[green]{entry.Key}[/] [grey]->[/] [white]{entry.Value}[/]");
            }

            AnsiConsole.Write(new Panel(grid).Header("Names Dictionary").BorderColor(Color.Grey));

            string? input = Console.ReadLine();
            Console.WriteLine("Enter 'exit' to return to menu.");
            if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
            {
                return;
            }
        }
    }
}
