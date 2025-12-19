namespace Code_challenges_Fundament_.Oppgaver.Oppgave2;

public class Addition
{
  public double Add(double num1, double num2)
  {
    return num1 + num2;
  }
  public double Add(List<double>numList)
  {
    double result = 0;
    foreach (var num in numList)
    {
      result += num;
    }
    return result;
  }
}