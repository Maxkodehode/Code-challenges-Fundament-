namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public class Subtraction
{
  public double Sub(double num1, double num2)
  {
    return num1 - num2;
  }
  public double Sub(List<double>numList)
  {
    double result = 0;
    foreach (var num in numList)
    {
      result -= num;
    }
    return result;
  }
}