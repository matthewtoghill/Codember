using System.Text.RegularExpressions;

namespace Challenge03;

public class Program
{
    private static readonly string[] _input = File.ReadAllLines(@"..\..\..\..\Data\challenge03.txt");

    private static void Main()
    {
        var results = _input.Select(ProcessInstructions).ToList();
        Console.WriteLine($"{results.Sum()}-{results[^1]}");
    }

    private static int ProcessInstructions(string line)
    {
        int index = 0, steps = 0;
        var instructions = line.ExtractInts().ToList();

        while (index >= 0 && index < instructions.Count)
        {
            steps++;
            var instruction = instructions[index];
            instructions[index]++;
            index += instruction;
        }

        return steps;
    }
}

internal static partial class Extensions
{
    public static IEnumerable<int> ExtractInts(this string text) => NumbersOnlyRegex().Matches(text).Select(m => int.Parse(m.Value));

    [GeneratedRegex(@"-?\d+")] private static partial Regex NumbersOnlyRegex();
}
