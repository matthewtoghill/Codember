namespace Challenge02;

public class Program
{
    private static readonly string[] _input = File.ReadAllLines(@"..\..\..\..\Data\challenge02.txt");

    private static void Main()
    {
        var validCount = 0;

        foreach (var line in _input)
        {
            if (IsValidAttempt(line)) validCount++;
        }

        Console.WriteLine($"{validCount}true{_input.Length - validCount}false");
    }

    private static bool IsValidAttempt(string line)
    {
        var hasLetter = false;
        var maxDigit = 0;
        var maxLetter = 'a';

        foreach (var item in line)
        {
            if (char.IsDigit(item))
            {
                if (hasLetter) return false;
                if (item - '0' < maxDigit) return false;
                maxDigit = item - '0';
            }

            if (char.IsLetter(item))
            {
                if (char.IsUpper(item)) return false;
                hasLetter = true;

                if (item < maxLetter) return false;
                maxLetter = item;
            }
        }

        return true;
    }
}
