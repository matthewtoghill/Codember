namespace Challenge03;

public class Program
{
    private static readonly string[] _input = File.ReadAllLines(@"..\..\..\..\Data\challenge03.txt");
    private static void Main()
    {
        Console.WriteLine($"{_input.Where(IsPasswordInvalid).ToArray()[41]}");
    }

    private static bool IsPasswordInvalid(string password)
    {
        var split = password.Split(["-", ":", " "], StringSplitOptions.RemoveEmptyEntries);
        var (min, max) = (int.Parse(split[0]), int.Parse(split[1]));
        var count = split[3].Count(c => c == split[2][0]);
        return !(min <= count && count <= max);
    }
}
