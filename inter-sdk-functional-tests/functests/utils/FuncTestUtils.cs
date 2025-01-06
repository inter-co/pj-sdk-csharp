namespace inter_sdk_functional_tests;

public class FuncTestUtils
{
    public static string GetString(string prompt)
    {
        Console.Write(prompt + ": ");
        return Console.ReadLine();
    }

    public static decimal GetBigDecimal(string prompt)
    {
        Console.Write(prompt + ": ");
        return decimal.Parse(Console.ReadLine());
    }
}
