using Challenge04;

namespace Challenge05;

public class Program
{
    private static readonly string[] _input = File.ReadAllText(@"..\..\..\..\Data\challenge04.txt").Split(["],", "[", "]]"], StringSplitOptions.RemoveEmptyEntries);

    private static void Main()
    {
        var graph = new Graph();

        foreach (var item in _input)
        {
            var connections = item.Split(',');
            graph.AddEdge(int.Parse(connections[0]), int.Parse(connections[1]));
        }

        var groups = graph.FindConnectedComponents();

        var healthyNodes = groups.Where(x => x.Count < 3).SelectMany(x => x).ToHashSet();
        List<int> result = [];

        foreach (var node in healthyNodes)
        {
            if (IsPrime(node) && IsPrime(SumOfDigits(node)))
                result.Add(node);
        }

        Console.WriteLine($"{result.Count}-{result[2]}");
    }

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        int boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }

    private static int SumOfDigits(int number) => number.ToString().Sum(x => x - '0');
}
