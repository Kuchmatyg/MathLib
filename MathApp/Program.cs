using MathLibrary;

public class Program
{
    public static void Main(string[] args)
    {
        double resultDouble = MathCalc.Divide("16,2", "8,1");
        var typeDouble = resultDouble.GetType();
        Console.WriteLine(typeDouble);
        Console.WriteLine(resultDouble);
    }
}