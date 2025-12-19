namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public static class CalculatingList
{
    // --- Error Code Constants (Private to this class) ---
    private const double ErrorInvalidExpressionSyntax = -222.22;// Invalid expression syntax
    private const double ErrorDivideByZero = -000.03;

    public static double ListProcessing(string[] parts)
    {
        //Convert to list
        List<string> expression = parts.ToList();
        
        //Iterate backwards in list to check for "*"or"/"
        for (int i = expression.Count - 1; i >= 0; i--)
        {
            string token = expression[i];
            
            if (token == "*" || token == "/")
            {
                // Validate surrounding elements
                if (i <= 0 || 
                    i >= expression.Count - 1 || 
                    !double.TryParse(expression[i - 1], out double num1) || 
                    !double.TryParse(expression[i + 1], out double num2))
                {
                    
                    return ErrorInvalidExpressionSyntax;// The expression syntax is invalid
                }
                
                double result = 0;
                
                try
                {
                    if (token == "*")
                    {
                        Multiplication multiplication = new Multiplication();
                        result = multiplication.Mult(num1, num2);
                    }
                    else // if token == "/"
                    {
                        Division division = new Division();
                        result = division.Div(num1, num2);
                    }
                }
                catch (DivideByZeroException)
                {
                    return ErrorDivideByZero;// Handle division by zero
                }
                
                
                expression.RemoveRange(i - 1, 3);// remove num1, operator, num2
                expression.Insert(i - 1, result.ToString());// insert result at num1's position
                
                i = expression.Count; 
            }
        }
        
        if (expression.Count == 0) //check if there are any remainer in the list
        {
            return 0;
        }
        
        
        if (!double.TryParse(expression[0], out double finalResult))// check if the first element is a valid number
        {
            return ErrorInvalidExpressionSyntax;// The expression syntax is invalid
        }

        // Process the rest of the list (which should only contain +, -, and numbers)
        for (int i = 1; i < expression.Count - 1; i += 2)
        {
            string op = expression[i];
            
            // Check if the element after the operator is a valid number
            if (!double.TryParse(expression[i + 1], out double num))
            {
                return ErrorInvalidExpressionSyntax;// The expression syntax is invalid
            }

            switch (op)
            {
                case "+":
                    Addition addition = new Addition();
                    finalResult = addition.Add(finalResult, num);
                    break;
                case "-":
                    Subtraction subtraction = new Subtraction();
                    finalResult = subtraction.Sub(finalResult, num);
                    break;
                default:
                    
                    return ErrorInvalidExpressionSyntax;// The expression syntax is invalid
            }
        }
        
        // expression should not end with an operator
        if (expression.Count > 1 && expression.Count % 2 == 0)
        {
            return ErrorInvalidExpressionSyntax;// The expression syntax is invalid
        }

        return finalResult;
    }
}