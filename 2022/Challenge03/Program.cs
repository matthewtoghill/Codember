namespace Challenge03;

public class Program
{
    private static readonly string[] _input = File.ReadAllText(@"..\..\..\..\Data\challenge03.txt").Trim().Replace("'", "")
                                                  .Split(new[] { "\n", ", ", "[", "]", " " }, StringSplitOptions.RemoveEmptyEntries);
    private static void Main()
    {
        var zebras = new List<(string colour, int length)>();
        for (int i = 0; i < _input.Length - 1; i++)
        {
            var colour1 = _input[i];
            var colour2 = _input[i + 1];
            var count = 1;
            bool isSecondary = true;

            for (int j = i + 1; j < _input.Length; j++)
            {
                var thisColour = _input[j];
                if (isSecondary && thisColour != colour2 || !isSecondary && thisColour != colour1)
                {
                    zebras.Add((_input[j - 1], count));
                    break;
                }

                count++;
                isSecondary = !isSecondary;
            }
        }

        var longest = zebras.MaxBy(x => x.length);
        Console.WriteLine($"{longest.length}@{longest.colour}");
    }
}