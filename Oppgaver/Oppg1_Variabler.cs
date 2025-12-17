using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Code_challenges_Fundament_;

public class Variabler
{
    string str = "This is a string";
    int number = 666;

    double withDecimals = 66.6;

    bool isTrue = true;

    char afterB = 'c';

    public void PopulateArray()
    {
        List<object> variables = new List<object> { str, number, withDecimals, isTrue, afterB };

        foreach (object item in variables)
        {
            string typeName = item.GetType().Name;

            AnsiConsole.MarkupLine(
                $"[grey]Type:[/][yellow]{typeName}[/], [grey]Value:[/][bold blue]{item}[/]"
            );
        }
    }
}
