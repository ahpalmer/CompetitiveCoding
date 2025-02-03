namespace CompetitiveProgramming;

public class CarnegieMellon
{
    public static void PrintPalindrome(int input)
    {
        string strInput = input.ToString();
        var reversed = new string(strInput.Reverse().ToArray());
        Console.WriteLine(strInput + reversed);
    }
}
