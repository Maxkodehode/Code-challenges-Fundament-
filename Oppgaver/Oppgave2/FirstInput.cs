using Spectre.Console;

namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public class FirstInput
{
    
    
    public void Run()
    {
            
        bool shouldExit = false; // Flag to control outer loop exit

        while (true)
        { 
            // Check if we should exit the program
            if (shouldExit) 
            {
                Console.WriteLine("Exiting calculator.");
                break; // Exits the outer loop
            }
                
            // Reset variables for a new calculation block
            double result = 0.0;
            bool hasInput = false;

            // --- Initial Input Prompt ---
            AnsiConsole.MarkupLine("[green]Enter your number an operations to calculate. e.g. 5+5. [/]");
            AnsiConsole.MarkupLine("[green]You can also type exit to return to menu or 'clear' to start a new calculation[/]");
            AnsiConsole.MarkupLine("[green]---------------------------------------------------------------------------------------[/]");  
            Console.Write("> ");
            string? input = Console.ReadLine();
            Calculate calculate = new Calculate();
                
            if (input == null)
            {
                // This case is largely handled by the -555.55 error code in ProcessInput
                AnsiConsole.MarkupLine("[red]No valid input detected[/]"); 
            }
            else
            {
                result = calculate.ProcessInput(input);
                    
                // Check special return codes after the first calculation
                if (result == Calculate.CommandExit)
                {
                    shouldExit = true;
                    continue; // Go to top to trigger exit check
                }
                else if (result == Calculate.CommandClear)
                {
                    AnsiConsole.MarkupLine("[green]Starting new calculation.[/]");
                    continue; // Go to top to restart
                }
                // Handle ALL error codes (any negative return code)
                else if (result == Calculate.ErrorDivideByZero ||
                         result == Calculate.ErrorInvalidOperator ||
                         result == Calculate.ErrorInvalidExpressionSyntax ||
                         result == Calculate.ErrorGenericFailure ||
                         result == Calculate.ErrorInvalidCharacter ||
                         result == Calculate.ErrorEmptyInput)
                {
                    HandleErrorDisplay(result);
                }
                else // Valid result
                {
                        
                    hasInput = true;
                }
            }
                
            // --- Continuation Prompt ---
            AnsiConsole.MarkupLine("[green]To continue calculating, you only need to input the operation followed by the value.[/]");
            AnsiConsole.MarkupLine("[green]Example: If the previous result was 5, typing +10 will calculate 5+10.[/]");
            AnsiConsole.MarkupLine("[green]---------------------------------------------------------------------------------------[/]");  
            AnsiConsole.MarkupLine($"[yellow]{result}[/]");
  
            // --- Continuation Loop ---
            while (hasInput)
            {
                Console.Write("> ");
                input = Console.ReadLine();
                    
                if (input == null)
                {
                    AnsiConsole.MarkupLine("[red]No valid input detected[/]");
                }
                else
                {
                    double previousResult = result;
                        
                    result = calculate.ProcessInput(input, previousResult);
                        
                    // Check special return codes inside the inner loop
                    if (result == Calculate.CommandExit)
                    {
                        shouldExit = true;
                        break; // Breaks inner loop, returns to outer loop check
                    }
                    else if (result == Calculate.CommandClear)
                    {
                        AnsiConsole.MarkupLine("[blue]Starting new calculation.[/]");
                        break; // Breaks inner loop, outer loop restarts
                    }
                    // Handle ALL error codes
                    else if (result < 0)
                    {
                        HandleErrorDisplay(result);
                        hasInput = false; // Stop continuation loop on error
                        break;
                    }
                        
                    AnsiConsole.MarkupLine($"[yellow]{result}[/]");
                }
            }
        }
    }
        
        
    static void HandleErrorDisplay(double errorCode)
    {
        // Use a switch expression for cleaner error mapping
        string message = errorCode switch
        {
            Calculate.ErrorDivideByZero => "Error: Cannot divide by zero.",
            Calculate.ErrorInvalidOperator => "Error: Invalid or unsupported operator.",
            Calculate.ErrorInvalidExpressionSyntax => "Error: Invalid expression format, missing operands, or incomplete operation.",
            Calculate.ErrorGenericFailure => "Error: An unknown processing error occurred.",
            Calculate.ErrorInvalidCharacter => "Error: Input contains an invalid character (must be a digit, '.', or an operator).",
            Calculate.ErrorEmptyInput => "Error: No valid input was provided.",
            _ => "Error: Unrecognized error code."
        };
        AnsiConsole.MarkupLine($"[red]{message} (Code: {errorCode})[/]");
    }
}