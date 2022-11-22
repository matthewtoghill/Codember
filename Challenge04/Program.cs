namespace Challenge04;

public class Program
{
    private static void Main()
    {
        var validPasswords = Enumerable.Range(11098, 98124 - 11098).Where(x => IsValid(x.ToString())).ToArray();
        Console.WriteLine($"{validPasswords.Length}-{validPasswords[55]}");
    }

    private static bool IsValid(string s)
        => s.Count(c => c == '5') >= 2
        && s.Zip(s.Skip(1), (a, b) => a <= b).All(x => x);
}
