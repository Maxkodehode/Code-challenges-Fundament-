namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public class Division
{
  public double Div(double num1, double num2)
  {
    double result = num1 / num2;
    return result;
  }


  public double Div(List<double>numList)
  {
    double result = 0;
    foreach (var num in numList)
    {
      if (num == 0)
      {
        throw new DivideByZeroException("The divisor cannot be zero.");
      }
      result /= num;
    }
    return result;
  }
}