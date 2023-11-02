namespace Challenge01;

public class Program
{
    private static readonly string[] _input = File.ReadAllText(@"..\..\..\..\Data\challenge01.txt").Split(' ');
    private static void Main()
    {
        foreach (var item in _input.GetFrequencies())
        {
            Console.Write($"{item.Key}{item.Value}");
        }
    }
}


public static class Extensions
{
    public static IEnumerable<KeyValuePair<T, int>> GetFrequencies<T>(this IEnumerable<T> items) where T : notnull
        => items.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
}