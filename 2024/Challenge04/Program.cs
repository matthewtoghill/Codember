namespace Challenge04;

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

        var result = groups.Where(x => x.Count < 3).SelectMany(x => x).ToHashSet();

        Console.WriteLine(string.Join(",", result));
    }
}
