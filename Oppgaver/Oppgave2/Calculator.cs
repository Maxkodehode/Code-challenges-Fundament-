using System.Text.RegularExpressions;

namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public class Calculate
{
    // --- Error Code Constants (Public for use in Program.cs) ---
    public const double CommandClear = -000.00;
    public const double CommandExit = -000.01;
    public const double ErrorDivideByZero = -000.03;
    public const double ErrorInvalidOperator = -111.11;
    public const double ErrorInvalidExpressionSyntax = -222.22;
    public const double ErrorGenericFailure = -333.33;
    public const double ErrorInvalidCharacter = -444.44;
    public const double ErrorEmptyInput = -555.55;

    string operation = "";
    double num1;
    double num2;
    bool hasInput;
    double result;

    public double ProcessInput(string input, double previousResult = 0.0)
    {
        if (input != null)
        {
            input = input.Trim();
        }

        // Check for empty input
        if (string.IsNullOrWhiteSpace(input))
        {
            return CommandExit;
        }

        if (input.ToLower() == "clear") // Check for 'clear' command
        {
            Console.Clear();
            return CommandClear;
        }
        else if (input.ToLower() == "exit") // Check for 'exit' command
        {
            return CommandExit;
        }

        string? resultString = previousResult.ToString();
        input = resultString + input;

        string pattern = @"^[0-9\.\+\-\*/\s]+$";

        // Return error if invalid characters are found
        if (!Regex.IsMatch(input, pattern))
        {
            return ErrorInvalidCharacter;
        }

        // Add spaces around operators for easier splitting
        string spacedInput = input
            .Replace("*", " * ")
            .Replace("/", " / ")
            .Replace("+", " + ")
            .Replace("-", " - ");

        string[] parts = spacedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Check length of array and confirm operator and digits index in array
        if (parts.Length > 3)
        {
            result = CalculatingList.ListProcessing(parts);
            return result; // return the result from the list calculation
        }
        // Handle simple two-number operations
        else if (parts.Length == 3)
        {
            operation = parts[1];
            bool isNum1 = double.TryParse(parts[0], out num1);
            bool isNum2 = double.TryParse(parts[2], out num2);

            if (isNum1 && isNum2)
            {
                hasInput = true;
            }

            if (hasInput)
            {
                // Perform the operation based on the operator
                switch (operation)
                {
                    case "+":
                        Addition addition = new Addition();
                        result = addition.Add(num1, num2);
                        break;
                    case "-":
                        Subtraction subtraction = new Subtraction();
                        result = subtraction.Sub(num1, num2);
                        break;
                    case "*":
                        Multiplication multiplication = new Multiplication();
                        result = multiplication.Mult(num1, num2);
                        break;
                    case "/":
                        Division division = new Division();
                        try
                        {
                            result = division.Div(num1, num2);
                        }
                        catch (DivideByZeroException)
                        {
                            return ErrorDivideByZero; // Handle division by zero
                        }
                        break;
                    default:
                        return ErrorInvalidOperator; // Invalid operator
                }
                return result; // Return the calculated result
            }
            else
            {
                return ErrorInvalidExpressionSyntax; // Invalid number format
            }
        }
        return ErrorGenericFailure; // Generic failure if none of the conditions are met
    }
}
