namespace Challenge04;

public class Program
{
    private static readonly string[] _input = File.ReadAllLines(@"..\..\..\..\Data\challenge04.txt");
    private static void Main()
    {
        var validFiles = new List<(string fileName, string checksum)>();
        foreach (var item in _input)
        {
            var split = item.Split('-');
            var fileName = split[0];
            var checksum = split[1];

            if (IsValid(fileName, checksum))
                validFiles.Add((fileName, checksum));
        }

        Console.WriteLine(validFiles[32].checksum);
    }

    private static bool IsValid(string fileName, string checksum)
        => checksum == new string(fileName.GetFrequencies().Where(x => x.Value == 1).Select(x => x.Key).ToArray());
}

public static class Extensions
{
    public static IEnumerable<KeyValuePair<T, int>> GetFrequencies<T>(this IEnumerable<T> items) where T : notnull
        => items.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
}