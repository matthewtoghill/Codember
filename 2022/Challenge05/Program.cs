using System.Text.Json;

namespace Challenge05;

public class Program
{
    private static readonly string[] _input = JsonSerializer.Deserialize<string[]>(File.ReadAllText(@"..\..\..\..\Data\challenge05.json"))!;
    private static void Main()
    {
        var patrons = _input.Select((x, i) => (name: x, index: i)).ToList();

        while (patrons.Count > 1)
        {
            for (int i = 0; i < patrons.Count; i++)
                patrons.RemoveAt((i + 1) % patrons.Count);
        }

        Console.WriteLine($"{patrons[0].name}-{patrons[0].index}");
    }
}
