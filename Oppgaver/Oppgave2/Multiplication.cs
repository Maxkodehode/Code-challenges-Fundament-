namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public class Multiplication
{
  public double Mult(double num1, double num2)
  {
    double result = num1 * num2;
    return result;
  }
  public double Mult(List<double>numList)
  {
    double result = 0;
    foreach (var num in numList)
    {
      result *= num;
    }
    return result;
  }
}